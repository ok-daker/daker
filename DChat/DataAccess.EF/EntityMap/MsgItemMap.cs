using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DChat.DataAccess.EF
{
    public class MsgItemMap: EntityTypeConfiguration<MsgItem>
    {
        public MsgItemMap()
        {
            this.ToTable("Msg_Item");
            this.HasKey(m=>m.Id);
        }
    }
}
