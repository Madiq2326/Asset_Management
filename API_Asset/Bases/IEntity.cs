using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.Bases
{
    public interface IEntity
    {
        [Key]
        int id { get; set; }
    }
}
