using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DChat.DataAccess.EF
{
    public class MsgItem
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public Guid ParentId { get; set; }
        public string MsgContent { get; set; }
        public DateTime SendTime { get; set; }
        [NotMapped]
        public MsgItem Next
        {

            get { return null; }
        }
        [NotMapped]
        public IList<MsgItem> NextAll
        {

            get { return null; }

        }
    }
}
