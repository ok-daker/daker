using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DChat.Model.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set;}
        public int Sex { get; set; }
        public int Class { get; set; }
        public string HeadImgPath { get; set;}
        public DateTime JoinTime { get; set; }
        public bool IsDeleted { get; set; }
        public string Remarks { get; set; }

        
    }
}
