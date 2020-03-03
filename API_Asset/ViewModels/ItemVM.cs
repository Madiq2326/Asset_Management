using API_Asset.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.ViewModels
{
    [Table("TB_M_Item")]
    public class ItemVM : BaseModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Stock { get; set; }
        public string Information { get; set; }
        public string Status { get; set; }
        public int Brand_id { get; set; }
        public int Supplier_id { get; set; }
    }
}
