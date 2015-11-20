using System;
using System.Collections;
using System.Collections.Generic;
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
        private const int MaxLength = 50;
        private const string OnlineUserKey = "User_Online";
        private const string MsgKey = "InChatingMessages";
        private const string DBKey = "ReadyToDB";
        public void Push(MsgItem msg)
        {
            msg = MsgHelper.GetMsgItem(msg);
            Queue<MsgItem> msgs = cache.Get<Queue<MsgItem>>(MsgKey)?? new Queue<MsgItem>();
            msgs.Enqueue(msg);
        }

        public IEnumerable<MsgItem> Get(Guid? id)
        {
            Queue<MsgItem> msgs = cache.Get<Queue<MsgItem>>(MsgKey) ?? new Queue<MsgItem>();
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
                return msgs.Skip(MaxLength - 10).Take(10).AsEnumerable();
            }
        }
    }
}
