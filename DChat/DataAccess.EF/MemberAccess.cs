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
        public static UserInfo Login(string name,string pwd)
        {
            using (ChatDbContext db = new ChatDbContext())
            {
                return db.UserInfos.FirstOrDefault(u => u.Name == name && u.Password == pwd);
            }
        }


    }
}
