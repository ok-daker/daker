using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DChat.Model.Models;

namespace DChat.Model.DTO
{
  public  class MsgItemDTO
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public string MsgContent { get; set; }
        public DateTime SendTime { get; set; }

        public UserInfo Sender { get; set; }
    }
}
