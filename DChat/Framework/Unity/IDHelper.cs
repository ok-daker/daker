using DChat.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
namespace DChat.Framework.Unity
{
    
    public static class IDHelper
    {
        private static object _root = new object();        
        public static MsgItem _preMsgItem;

        static IDHelper()
        {
            _preMsgItem = GetPreItem();
        }

        public static MsgItem GetMsgItem(MsgItem msgItem)
        {
            lock (_root)
            {
                msgItem.Id = Guid.NewGuid();
                msgItem.Pre = _preMsgItem;
                _preMsgItem = msgItem;
                return msgItem;
            }
        }
        /// <summary>
        /// 获取历史ID:数据库中获取
        /// </summary>
        /// <returns></returns>
        public static MsgItem GetPreItem()
        {
            return new MsgItem { };
        }
    }
}
