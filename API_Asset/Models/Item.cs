using API_Asset.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.Models
{
    [Table("tb_m_item")]
    public class Item : BaseModel, IEntity
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Stock { get; set; }
        public string Information { get; set; }
        public string Status { get; set; }
        public int Brand_id { get; set; }

        [ForeignKey("Brand_id")]
        public Brand Brand { get; set; }
    }
}
