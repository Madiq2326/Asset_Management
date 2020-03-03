using API_Asset.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.Models
{
    [Table("TB_M_Lend")]
    public class Lend : BaseModel
    {
        public int Employee_id { get; set; }
        public DateTime Lend_Date { get; set; }
        public DateTime Approve_Date_1 { get; set; }
        public DateTime Approve_Date_2 { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }
        public string Damage_Level { get; set; }
        public string Damage_Type { get; set; }
        public int Item_id { get; set; }

        [ForeignKey("Item_id")]
        public Item Item { get; set; }
    }
}
