using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DChat.Core.interfaces
{
    public interface IMsgHander
    {
        /// <summary>
        /// 一般前置处理
        /// </summary>
        void Pre();
        /// <summary>
        /// 一般核心处理
        /// </summary>
        void Core();
        /// <summary>
        /// 一般未处理
        /// </summary>
        void Tail();
        /// <summary>
        /// 其他插件处理
        /// </summary>
        void Extra();
    }
}
