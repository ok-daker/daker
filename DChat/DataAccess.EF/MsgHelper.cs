using DChat.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace DChat.DataAccess.EF
{
    
    public static class MsgHelper
    {
        private static object _root = new object();        
        public static MsgItem _preMsgItem;
        public static IEnumerable<MsgItem> _nextAllItem;

        static MsgHelper()
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
        /// 获取上一条消息记录:数据库中获取
        /// </summary>
        /// <returns></returns>
        public static MsgItem GetPreItem()
        {
            return new MsgItem { };
        }

        public static IEnumerable<MsgItem> GetNextAll(MsgItem msgItem )
        {
            if (IsGuid(msgItem.Id.ToString()))
            {
                //查询数据库 得到所有以当前msgItem.Id为parent_id的MsgItems 发送时间升序排列 并赋值给_nextAllItem
                //创建上下文
               
            }
            return new List<MsgItem>();
        }
        /// <summary>
        /// 判断MsgItem.Id是否为GUID
        /// </summary>
        /// <param name="strSrc"></param>
        /// <returns></returns>
        private static bool IsGuid(string strSrc)
        {
            if (string.IsNullOrEmpty(strSrc))
            {
                return false;
            }
            else
            {
                Regex reg = new Regex("^[A-F0-9]{8}(-[A-F0-9]{4}){3}-[A-F0-9]{12}$", RegexOptions.Compiled);
                return reg.IsMatch(strSrc);
            }
        }
    }
}
