using API_Asset.Models;
using API_Asset.MyConnections;
using API_Asset.Repositories.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ConnectionString _connectionString;

        private readonly DynamicParameters param = new DynamicParameters();

        public SupplierRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public IQueryable<Supplier> Get()
        {
            var result = _connectionString.Connections.QueryAsync<Supplier>("CALL SP_Retrive_All_Supplier").Result.AsQueryable();
            return result;
        }

        public Supplier Get(int Id)
        {
            var procname = "SP_Retrive_Supplier_ById";
            param.Add("sp_id", Id);
            var result = _connectionString.Connections.QueryAsync<Supplier>(procname, param, commandType: System.Data.CommandType.StoredProcedure).Result.SingleOrDefault();
            return result;
        }

        public int Post(Supplier supplier)
        {
            var procname = "SP_Insert_Supplier";
            param.Add("sp_name", supplier.Name);
            param.Add("sp_phone_number", supplier.Phone_Number);
            param.Add("sp_address", supplier.Address);
            param.Add("sp_email", supplier.Email);
            param.Add("sp_createdate", DateTime.Now);
            var post = _connectionString.Connections.ExecuteAsync(procname, param, commandType: System.Data.CommandType.StoredProcedure).Status;

            if (post != TaskStatus.Faulted)
            {
                return 1;
            }
            return 0;
        }

        public int Put(int Id, Supplier supplier)
        {
            var procname = "SP_Update_Supplier";
            param.Add("sp_id", Id);
            param.Add("sp_name", supplier.Name);
            param.Add("sp_phone_number", supplier.Phone_Number);
            param.Add("sp_address", supplier.Address);
            param.Add("sp_email", supplier.Email);
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
            var procname = "SP_Delete_Supplier";
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
