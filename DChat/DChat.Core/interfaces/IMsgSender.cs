using DChat.Model.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DChat.Core.interfaces
{
    public interface IMsgSender
    {
        void SendAll(IEnumerable<FlowBase> remains);
        void DeferSend(IEnumerable<FlowBase> remains);

    }
}
