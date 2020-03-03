using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.Bases
{
    public interface IEntity
    {
        int Id { get; set; }
        bool IsDelete { get; set; }
        void Create();
        void Update();
        void Delete();
    }
}
