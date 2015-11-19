using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DChat.Model.Models;
using DChat.Model.DTO;

namespace DChat.Core.interfaces
{
    public interface IMsgHandler
    {
        void Push(MsgItem msg);
        IEnumerable<MsgItemDTO> Get(Guid id);
    }
}
