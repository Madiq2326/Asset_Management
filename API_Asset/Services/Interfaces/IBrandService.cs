using API_Asset.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.Services.Interfaces
{
    public interface IBrandService
    {
        IQueryable<Brand> Get();

        Brand Get(int Id);

        int Post(Brand brand);

        int Put(int Id, Brand brand);

        bool Delete(int Id);
    }
}
