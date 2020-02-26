using API_Asset.Models;
using API_Asset.MyConnections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using API_Asset.Repositories.Interfaces;

namespace API_Asset.Repositories
{
    public class BrandRepository : GeneralRepository<Brand>, IBrandRepository
    {
        private readonly ConnectionString _connectionString;

        private readonly DynamicParameters param = new DynamicParameters();

        public BrandRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public IQueryable<Brand> Get()
        {
            var result = _connectionString.Connections.QueryAsync<Brand>("CALL SP_Retrive_All_Brand").Result.AsQueryable();
            return result;
        }

        public Brand Get(int Id)
        {
            var procname = "SP_Retrive_Brand_ById";
            param.Add("sp_id", Id);
            var result = _connectionString.Connections.QueryAsync<Brand>(procname, param, commandType: System.Data.CommandType.StoredProcedure).Result.SingleOrDefault();
            return result;
        }

        public int Post(Brand brand)
        {
            var procname = "SP_Insert_Brand";
            param.Add("sp_name", brand.Name);
            param.Add("sp_createdate", DateTime.Now);
            var post = _connectionString.Connections.ExecuteAsync(procname, param, commandType: System.Data.CommandType.StoredProcedure).Status;

            if (post != TaskStatus.Faulted)
            {
                return 1;
            }
            return 0;
        }

        public int Put(int Id, Brand brand)
        {
            var procname = "SP_Update_Brand";
            param.Add("sp_id", Id);
            param.Add("sp_name", brand.Name);
            param.Add("sp_updatedate", DateTime.Now);
            var put = _connectionString.Connections.ExecuteAsync(procname, param, commandType: System.Data.CommandType.StoredProcedure).Status;

            if (put != TaskStatus.Faulted)
            {
                return 1;
            }
            return 0;
        }

        public bool Delete(int Id)
        {
            var procname = "SP_Delete_Brand";
            param.Add("sp_id", Id);
            param.Add("sp_deletedate", DateTime.Now);
            var delete = _connectionString.Connections.ExecuteAsync(procname, param, commandType: System.Data.CommandType.StoredProcedure).Status;

            if (delete != TaskStatus.Faulted)
            {
                return true;
            }
            return false;
        }
    }
}
