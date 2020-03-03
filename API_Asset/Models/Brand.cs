using API_Asset.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.Models
{
    [Table("TB_M_Brand")]
    public class Brand : BaseModel
    {
        public string Name { get; set; }
    }
}
