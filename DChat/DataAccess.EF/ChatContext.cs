using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DChat.DataAccess.EF
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext()
            : base("name=Chat")
        {
            this.Configuration.AutoDetectChangesEnabled = true;
        }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<MsgItem> MsgItem { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserInfoMap());
            modelBuilder.Configurations.Add(new MsgItemMap());
        }
    }
}
