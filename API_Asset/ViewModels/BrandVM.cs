using API_Asset.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.ViewModels
{
    [Table("TB_M_Brand")]
    public class BrandVM : BaseModel
    {
        public string Name { get; set; }
    }
}
