using DChat.Core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DChat.DataAccess;
using DChat.Framework.IOC;

namespace DChat.Core.implement
{
    class MemberService : IMemberService
    {
        public Model.Models.UserInfo Login(string name, string pwd)
        {
            return MemberAccess.Login(name, pwd);
        }
    }
}
