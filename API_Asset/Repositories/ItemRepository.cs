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
    public class ItemRepository : IItemRepository
    {
        private readonly ConnectionString _connectionString;

        private readonly DynamicParameters param = new DynamicParameters();

        public ItemRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public IQueryable<Item> Get()
        {
            var result = _connectionString.Connections.QueryAsync<Item>("CALL SP_Retrive_All_Item").Result.AsQueryable();
            return result;
        }

        public Item Get(int Id)
        {
            var procname = "SP_Retrive_Item_ById";
            param.Add("sp_id", Id);
            var result = _connectionString.Connections.QueryAsync<Item>(procname, param, commandType: System.Data.CommandType.StoredProcedure).Result.SingleOrDefault();
            return result;
        }

        public int Post(Item item)
        {
            var procname = "SP_Insert_Item";
            param.Add("sp_name", item.Name);
            param.Add("sp_type", item.Type);
            param.Add("sp_stock", item.Stock);
            param.Add("sp_info", item.Information);
            param.Add("sp_status", item.Status);
            param.Add("sp_brand_id", item.Brand_id);
            param.Add("sp_createdate", DateTime.Now);
            var post = _connectionString.Connections.ExecuteAsync(procname, param, commandType: System.Data.CommandType.StoredProcedure).Status;

            if (post != TaskStatus.Faulted)
            {
                return 1;
            }
            return 0;
        }

        public int Put(int Id, Item item)
        {
            var procname = "SP_Update_Item";
            param.Add("sp_id", Id);
            param.Add("sp_name", item.Name);
            param.Add("sp_type", item.Type);
            param.Add("sp_stock", item.Stock);
            param.Add("sp_info", item.Information);
            param.Add("sp_status", item.Status);
            param.Add("sp_brand_id", item.Brand_id);
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
            var procname = "SP_Delete_Item";
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
