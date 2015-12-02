using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DChat.Core.interfaces;
using DChat.DataAccess;
using DChat.Model.Models;
using DChat.Framework.Cache;
using DChat.Framework.IOC;
using DChat.Model.DTO;

namespace DChat.Core.implement
{
    class MsgHandler : IMsgHandler
    {
        private readonly IRedisCache cache = Resolver.Current.Resolve<IRedisCache>();
        private readonly int MaxLength = Convert.ToInt32(ConfigurationManager.AppSettings["DefaultInChattingLength"]);
        private readonly int DefaultMsgLength = Convert.ToInt32(ConfigurationManager.AppSettings["DefaultReturnMsgLength"]);
        private const string OnlineUserKey = "User_Online";
        private const string MsgKey = "InChatingMessages";
        private const string DBKey = "ReadyToDB";
        public void Push(MsgItem msg)
        {
            msg = MsgHelper.GetMsgItem(msg);
            Queue<MsgItem> msgs;
            try
            {
                msgs = cache.Get<Queue<MsgItem>>(MsgKey) ?? new Queue<MsgItem>();
            }
            catch (Exception ex)
            {

                msgs = new Queue<MsgItem>();
            }

            msgs.Enqueue(msg);
            if (msgs.Count > MaxLength)
            {
                //多余的 消息放到数据库缓存 准备存到数据库中
                IEnumerable<MsgItem> msgsToDBTemp = msgs.Take(msgs.Count - MaxLength).AsEnumerable<MsgItem>();
                Queue<MsgItem> msgsToDB = cache.Get<Queue<MsgItem>>(DBKey) ?? new Queue<MsgItem>();
                foreach (MsgItem item in msgsToDBTemp)
                {
                    msgsToDB.Enqueue(msgs.Dequeue());
                }
                if (msgsToDB.Count >= MaxLength)
                {
                    //写入数据库操作 
                    //并清0 缓存
                    msgsToDB.Clear();

                }
                cache.Add(DBKey, msgsToDB);
            }
            cache.Add(MsgKey, msgs);

        }

        public IEnumerable<MsgItem> Get(Guid? id)
        {
            Queue<MsgItem> msgs;
            try
            {
                msgs = cache.Get<Queue<MsgItem>>(MsgKey) ?? new Queue<MsgItem>();
            }
            catch (Exception)
            {

                msgs = new Queue<MsgItem>();
            }

            //判断当前请求Id在不在缓存对列中
            //if (msgs.AsEnumerable<MsgItem>().Where(m => m.Id == id).Count() > 0)            
            int index = (id == null) ? -1 : msgs.Select(m => m.Id).ToList().IndexOf(id.Value);
            if (index != -1)
            {

                return msgs.Skip(index + 1).Take(50 - index).AsEnumerable();
            }
            //不在则返回缓存中最新的10条记录
            else
            {
                int _startIndex = msgs.Count <= DefaultMsgLength ? 0 : msgs.Count - DefaultMsgLength;
                return msgs.Skip(_startIndex).Take(DefaultMsgLength).AsEnumerable();
            }
        }
    }
}
