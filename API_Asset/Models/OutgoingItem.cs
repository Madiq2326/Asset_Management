﻿using API_Asset.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.Models
{
    [Table("TB_R_Outgoingitem")]
    public class OutgoingItem : BaseModel
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Information { get; set; }
        public DateTime Outgoing_Date { get; set; }
        public int Item_id { get; set; }

        //[ForeignKey("Item_id")]
        //public Item Item { get; set; }
    }
}
