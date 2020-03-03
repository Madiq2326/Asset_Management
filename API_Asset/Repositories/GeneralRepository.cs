using API_Asset.Bases;
using API_Asset.MyConnections;
using API_Asset.Repositories.Interfaces;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.Repositories
{
    public class GeneralRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly ConnectionString _connectionString;

        public GeneralRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            var getall = await _connectionString.Connections.GetAllAsync<TEntity>();
            return getall;
        }

        public async Task<TEntity> Get(int Id)
        {
            var get = await _connectionString.Connections.GetAsync<TEntity>(Id);
            return get;
        }

        public async Task<int> Post(TEntity entity)
        {
            var post = await _connectionString.Connections.InsertAsync(entity);
            return post;
        }

        public async Task<bool> Put(TEntity entity)
        {
            var put = await _connectionString.Connections.UpdateAsync(entity);
            return put;
        }

        public async Task<bool> Delete(int Id)
        {
            var entity = await _connectionString.Connections.GetAsync<TEntity>(Id);
            var delete = await _connectionString.Connections.DeleteAsync(entity);
            return delete;
        }
    }
}
