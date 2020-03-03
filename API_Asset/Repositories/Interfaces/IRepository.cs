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
        Task<IEnumerable<T>> Get();
        Task<T> Get(int Id);
        Task<int> Post(T entity);
        Task<bool> Put(T entity);
        Task<bool> Delete(int Id);
    }
}
