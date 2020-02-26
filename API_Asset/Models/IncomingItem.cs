using API_Asset.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.Models
{
    [Table("tb_r_incominitem")]
    public class IncomingItem : IEntity
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Information { get; set; }
        public DateTime Incoming_date { get; set; }
        public int Supplier_id { get; set; }
        public int Item_id { get; set; }

        [ForeignKey("Supplier_id")]
        public Supplier Supplier { get; set; }

        [ForeignKey("Item_id")]
        public Item Item { get; set; }

    }
}
