using DChat.Core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DChat.Core.factory
{
    public class MsgFactory
    {
        public IMsgHander GetHander() 
        { return null; }
        public IMsgSender GetSender()
        { return null; }
        public IReceiver GetReceiver()
        { return null; }
    }
}
