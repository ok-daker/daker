using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DChat.Model.Models;

namespace DChat.Core.interfaces
{
    public interface IMemberService
    {
        UserInfo Login(string name, string pwd);
        UserInfo Regester(UserInfo usr);
        bool Exsist(string name);
        UserInfo GetByID(int id);
    }
}
