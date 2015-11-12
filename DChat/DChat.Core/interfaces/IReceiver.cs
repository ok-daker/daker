using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DChat.Core.interfaces
{
    public interface IReceiver
    {
        /// <summary>
        /// 获取客户端数据，并：返回/缓存；
        /// </summary>
        void HttpReceive();
        void TcpReveive();
        void ReveiveAll();
        void CloseHttp();
        void CloseTcp();
        void CloseAll();
    }
}
