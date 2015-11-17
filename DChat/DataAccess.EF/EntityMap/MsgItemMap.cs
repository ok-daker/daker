using DChat.Model.Models;
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
            //表名
            this.ToTable("Msg_Item");
            //主键
            this.HasKey(m=>m.Id);
            //字段类型 名称
            this.Property(m => m.SendTime).HasColumnName("send_time");
            this.Property(m => m.SendTime).HasColumnType("datetime");

            this.Property(m => m.UserId).HasColumnName("user_id");
            this.Property(m => m.UserId).HasColumnType("int");

            //this.Property(m => m.ParentId).HasColumnName("parent_id");

            this.Property(m => m.MsgContent).HasColumnName("msg_content");
            this.Property(m => m.MsgContent).HasColumnType("longtext");

            //this.Property(m => m.IsDeleted).HasColumnName("is_deleted");
            //this.Property(m => m.IsDeleted).HasColumnType("bit");
            this.HasOptional(c => c.Next).WithOptionalPrincipal(d => d.Pre).Map(k => { k.MapKey("parent_id"); });

        }
    }
}
