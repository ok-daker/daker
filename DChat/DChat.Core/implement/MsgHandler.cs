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
        public void Push(MsgItem msg)
        {
            msg = MsgHelper.GetMsgItem(msg);
            Queue<MsgItem> msgs = cache.Get<Queue<MsgItem>>(MsgKey);
            msgs = msgs ?? new Queue<MsgItem>();
            msgs.Add(msg);
        }

        public IEnumerable<MsgItem> Get(Guid? id)
        {
            Queue<MsgItem> msgs = cache.Get<Queue<MsgItem>>(MsgKey) ?? new Queue<MsgItem>();
            int index = (id == null) ? -1 : msgs.Select(m => m.Id).ToList().IndexOf(id.Value);
            return msgs.Skip(index + 1).Take(50 - index).AsEnumerable();
        }
    }
}
