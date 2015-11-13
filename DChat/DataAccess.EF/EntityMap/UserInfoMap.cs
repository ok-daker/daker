using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DChat.DataAccess.EF
{
    public class UserInfoMap:EntityTypeConfiguration<UserInfo>
    {
        public UserInfoMap()
        {
            this.ToTable("User_Info");
            this.HasKey(u=>u.Id);
        }
    }
}
