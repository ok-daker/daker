using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
namespace DChat.Framework.Unity
{
    public class IDPair
    {
        public Guid ParentID { get; set; }
        public Guid Msg_ID { get; set; }
    }

    public static class IDHelper
    {
        private static object _root = new object();
        private static Guid   _parentId;
        private static Guid _currentId;

        static IDHelper()
        {
            _parentId = GetHistoryID();
        }

        public static IDPair GetIDPair()
        {
            lock (_root)
            {
                _parentId = _currentId;
                _currentId = Guid.NewGuid();
                return new IDPair() { Msg_ID = _currentId, ParentID = _parentId };
            }


        }
        /// <summary>
        /// 获取历史ID:数据库中获取
        /// </summary>
        /// <returns></returns>
        public static Guid GetHistoryID()
        {
            return Guid.Parse("ef5b6cbe-31af-431a-9a19-eb3a72393360");
        }
    }
}
