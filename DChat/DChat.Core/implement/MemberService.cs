using DChat.Core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DChat.DataAccess;
using DChat.Framework.IOC;
using DChat.Model.Models;

namespace DChat.Core.implement
{
    class MemberService : IMemberService
    {
        public Model.Models.UserInfo Login(string name, string pwd)
        {
            return MemberAccess.Login(name, pwd);
        }


        public Model.Models.UserInfo Regester(Model.Models.UserInfo usr)
        {
            return MemberAccess.Regester(usr);
        }

        public bool Exsist(string name)
        {
            return MemberAccess.Exist(name);
        }

        public UserInfo GetByID(int id)
        {
            return MemberAccess.GetByID(id);
        }
    }
}
