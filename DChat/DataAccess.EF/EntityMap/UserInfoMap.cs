using DChat.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DChat.DataAccess
{
    public class UserInfoMap : EntityTypeConfiguration<UserInfo>
    {
        public UserInfoMap()
        {
            //表名
            this.ToTable("User_Info");
            //主键
            this.HasKey(u => u.Id);
            //字段类型  名称 是否可空等属性

            this.Property(m => m.Name).HasColumnName("name");
            this.Property(m => m.Name).HasColumnType("varchar");
            this.Property(m => m.Name).HasMaxLength(100);

            this.Property(m => m.NickName).HasColumnName("nick_name");
            this.Property(m => m.NickName).HasColumnType("varchar");
            this.Property(m => m.NickName).HasMaxLength(100);

            this.Property(m => m.Email).HasColumnName("email");
            this.Property(m => m.Email).HasColumnType("varchar");
            this.Property(m => m.Email).HasMaxLength(200);

            this.Property(m => m.Password).HasColumnName("password");
            this.Property(m => m.Password).HasColumnType("varchar");
            this.Property(m => m.Password).HasMaxLength(200);

            this.Property(m => m.Sex).HasColumnName("six");
            this.Property(m => m.Sex).HasColumnType("int");

            this.Property(m => m.Class).HasColumnName("class");
            this.Property(m => m.Class).HasColumnType("int");

            this.Property(m => m.HeadImgPath).HasColumnName("head_img_path");
            this.Property(m => m.HeadImgPath).HasColumnType("varchar");
            this.Property(m => m.HeadImgPath).HasMaxLength(300);

            this.Property(m => m.JoinTime).HasColumnName("join_time");
            this.Property(m => m.JoinTime).HasColumnType("datetime");

            this.Property(m => m.IsDeleted).HasColumnName("is_deleted");
            this.Property(m => m.IsDeleted).HasColumnType("bit");

            this.Property(m => m.Remarks).HasColumnName("remarks");
            this.Property(m => m.Remarks).HasColumnType("varchar");
            this.Property(m => m.Remarks).HasMaxLength(600);

        }
    }
}
