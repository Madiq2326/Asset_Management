using API_Asset.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.ViewModels
{
    public class ItemInVM : BaseModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Stock { get; set; }
        public DateTime Incoming_date { get; set; }
        public string Information { get; set; }
        public string Status { get; set; }
        public int Brand_id { get; set; }
        public int Supplier_id { get; set; }
        public int Item_id { get; set; }
        public int Temp { get; set; }
    }
}
