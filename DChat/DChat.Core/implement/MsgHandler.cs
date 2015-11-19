using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DChat.Core.interfaces;
using DChat.Model.Models;
using DChat.Framework.Cache;
using DChat.Framework.IOC;
using DChat.Model.DTO;

namespace DChat.Core.implement
{
    class MsgHandler : IMsgHandler
    {
        private IRedisCache cache = Resolver.Current.Resolve<IRedisCache>();
        public void Push(MsgItem msg)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MsgItemDTO> Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
