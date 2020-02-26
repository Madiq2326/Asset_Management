using API_Asset.MyConnections;
using API_Asset.Repositories.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.Repositories
{
    public class GeneralRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public IQueryable<TEntity> Get()
        {
            throw new NotImplementedException();
        }

        public TEntity Get(int Id)
        {
            throw new NotImplementedException();
        }

        public int Post(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public int Put(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
