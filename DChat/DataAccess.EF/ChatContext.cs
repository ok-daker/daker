using DChat.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DChat.DataAccess
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext()
            : base("name=Chat")
        {
           // this.Configuration.AutoDetectChangesEnabled = true;
        }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<MsgItem> MsgItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserInfoMap());
            modelBuilder.Configurations.Add(new MsgItemMap());
        }
    }
}
