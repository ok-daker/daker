using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DChat.Model.Models;

namespace DChat.Web.context
{
    public static class UsersContext
    {
        private static List<UserInfo> _users = new List<UserInfo>();

        public static List<UserInfo> Users
        {
            get { return _users; }
            private set { _users = value; }
        }

        public static void AddOnLine(UserInfo usr)
        {
            _users.Add(usr);
        }

        public static void SetOffLine(int id)
        {
            if (_users.Count(u => u.Id == id) > 0)
            {
                _users.Remove(_users.FirstOrDefault(u => u.Id == id));
            }
        }
    }
}