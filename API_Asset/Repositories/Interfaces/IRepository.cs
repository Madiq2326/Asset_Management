using API_Asset.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.Repositories.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        IQueryable<T> Get();
        T Get(int Id);
        int Post(T entitye);
        int Put(T entity);
        bool Delete(int Id);
    }
}
