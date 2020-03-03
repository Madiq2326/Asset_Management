using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.ViewModels
{
    public class LIst_ItemVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Stock { get; set; }
        public string Information { get; set; }
        public string Status { get; set; }
        public string Brand { get; set; }
        public string Supplier { get; set; }
    }
}
