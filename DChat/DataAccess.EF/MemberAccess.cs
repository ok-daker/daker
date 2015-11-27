using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DChat.Model.Models;

namespace DChat.DataAccess
{
    public class MemberAccess
    {
        public static UserInfo Login(string name, string pwd)
        {
            using (ChatDbContext db = new ChatDbContext())
            {
                return db.UserInfos.FirstOrDefault(u => u.Name == name && u.Password == pwd);
            }
        }

        public static UserInfo Regester(UserInfo usr)
        {
            using (ChatDbContext db = new ChatDbContext())
            {
                var ur = db.UserInfos.Add(usr);
                db.SaveChanges();
                return ur;
            }

        }
        public static bool Exist(string usrName)
        {
            using (ChatDbContext db = new ChatDbContext())
            {
                var ur = db.UserInfos.Any(u => u.Name == usrName);

                return ur;
            }

        }
        public static UserInfo GetByID(int id)
        {
            using (ChatDbContext db = new ChatDbContext())
            {
                var ur = db.UserInfos.FirstOrDefault(u => u.Id == id);
                return ur;
            }

        }

    }
}
