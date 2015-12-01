using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using DChat.Framework.Cache;
using DChat.Framework.IOC;
using DChat.Model.Models;

namespace DChat.Core.context
{
    public static class UsersContext
    {
        private static readonly IRedisCache cache = Resolver.Current.Resolve<IRedisCache>();
        private const string ONLINE_USERS_KEY = "online_users";

        public static List<UserInfo> _users
        {
            get
            {
                try
                {
                    var usrs = cache.Get<List<UserInfo>>(ONLINE_USERS_KEY);
                    return usrs ?? new List<UserInfo>();
                }
                catch (Exception ex)
                {
                    return  new List<UserInfo>();
                    //return  new  List<UserInfo>();
                }

            }
            set
            {
                cache.Add(ONLINE_USERS_KEY, value);

            }
        }

        public static List<UserInfo> Users
        {
            get { return _users; }
            private set { _users = value; }
        }
        public static void AddOnLine(UserInfo usr)
        {
            if (_users.Count(u => u.Id == usr.Id) <= 0)
            {
                var usrs = _users;
                usrs.Add(usr);
                _users = usrs;
            }

        }

        public static void SetOffLine(int id)
        {
            if (_users.Count(u => u.Id == id) > 0)
            {
                var usrs = _users;
                usrs.Remove(usrs.FirstOrDefault(u => u.Id==id));
                _users = usrs;
            }
        }
    }
}