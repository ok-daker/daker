﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DChat.Model.Models
{
    public class MsgItem
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        //public Guid ParentId { get; set; }
        public string MsgContent { get; set; }
        public DateTime SendTime { get; set; }

        public virtual MsgItem Next { get; set; }

        public virtual MsgItem Pre { get; set; }

        public IList<MsgItem> NextAll
        {

            get { return null; }

        }
    }
}