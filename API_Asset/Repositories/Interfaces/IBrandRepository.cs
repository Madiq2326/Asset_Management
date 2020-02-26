using API_Asset.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        IQueryable<Brand> Get();

        Brand Get(int Id);

        int Post(Brand item);

        int Put(int Id, Brand item);

        bool Delete(int Id);
    }
}
