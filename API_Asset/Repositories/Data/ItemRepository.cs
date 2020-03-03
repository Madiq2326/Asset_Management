using API_Asset.Models;
using API_Asset.MyConnections;
using API_Asset.Repositories.Interfaces;
using API_Asset.ViewModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.Repositories.Data
{
    public class ItemRepository : GeneralRepository<Item>
    {
        private readonly ConnectionString _connectionString;

        public DynamicParameters parameters = new DynamicParameters();

        public ItemRepository(ConnectionString connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<LIst_ItemVM> Get_List()
        {
            var query = "SP_List_Item";
            var get = _connectionString.Connections.Query<LIst_ItemVM>(query, commandType: CommandType.StoredProcedure);
            return get;
        }

        public int Multiple_Post(ItemInVM itemInVM)
        {
            var query = "SP_Insert_Item";
            parameters.Add("@sp_name", itemInVM.Name);
            parameters.Add("@sp_type", itemInVM.Type);
            parameters.Add("@sp_stock", itemInVM.Stock);
            parameters.Add("@sp_info", itemInVM.Information);
            parameters.Add("@sp_status", itemInVM.Status);
            parameters.Add("@sp_brand_id", itemInVM.Brand_id);
            parameters.Add("@sp_sup_id", itemInVM.Supplier_id);
            parameters.Add("@sp_createdate", itemInVM.CreateDate);
            var post = _connectionString.Connections.Execute(query, parameters, commandType: CommandType.StoredProcedure);

            var queryget = "SP_Retrive_Id_ByItem";
            parameters.Add("@sp_name", itemInVM.Name);
            parameters.Add("@sp_type", itemInVM.Type);
            parameters.Add("@sp_stock", itemInVM.Stock);
            var get = _connectionString.Connections.Query<Item>(queryget, parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();

            var query2 = "SP_Insert_IncomingItem";
            parameters.Add("@sp_name", itemInVM.Name);
            parameters.Add("@sp_stock", itemInVM.Stock);
            parameters.Add("@sp_info", itemInVM.Information);
            parameters.Add("@sp_date", DateTime.Now);
            parameters.Add("@sp_item_id", get.Id);
            var post2 = _connectionString.Connections.Execute(query2, parameters, commandType: CommandType.StoredProcedure);

            if(post > 0 && post2 > 0)
            {
                return 1;
            }
            return 0;
        }

        public int Update_In(int Id, ItemInVM itemInVM)
        {
            var query = "SP_Update_Item";
            parameters.Add("@sp_id", Id);
            parameters.Add("@sp_name", itemInVM.Name);
            parameters.Add("@sp_type", itemInVM.Type);
            parameters.Add("@sp_stock", itemInVM.Stock);
            parameters.Add("@sp_info", itemInVM.Information);
            parameters.Add("@sp_status", itemInVM.Status);
            parameters.Add("@sp_brand_id", itemInVM.Brand_id);
            parameters.Add("@sp_sup_id", itemInVM.Supplier_id);
            parameters.Add("@sp_updatedate", itemInVM.UpdateDate);
            var post = _connectionString.Connections.Execute(query, parameters, commandType: CommandType.StoredProcedure);

            var query2 = "SP_Insert_IncomingItem";
            parameters.Add("@sp_name", itemInVM.Name);
            parameters.Add("@sp_stock", itemInVM.Temp);
            parameters.Add("@sp_info", itemInVM.Information);
            parameters.Add("@sp_date", DateTime.Now);
            parameters.Add("@sp_item_id", Id);
            parameters.Add("@sp_isdelete", false);
            var post2 = _connectionString.Connections.Execute(query2, parameters, commandType: CommandType.StoredProcedure);

            if (post > 0 && post2 > 0)
            {
                return 1;
            }
            return 0;
        }

        public int Update_Out(int Id, ItemInVM itemInVM)
        {
            var query = "SP_Update_Item";
            parameters.Add("@sp_id", Id);
            parameters.Add("@sp_name", itemInVM.Name);
            parameters.Add("@sp_type", itemInVM.Type);
            parameters.Add("@sp_stock", itemInVM.Stock);
            parameters.Add("@sp_info", itemInVM.Information);
            parameters.Add("@sp_status", itemInVM.Status);
            parameters.Add("@sp_brand_id", itemInVM.Brand_id);
            parameters.Add("@sp_sup_id", itemInVM.Supplier_id);
            parameters.Add("@sp_updatedate", itemInVM.UpdateDate);
            var post = _connectionString.Connections.Execute(query, parameters, commandType: CommandType.StoredProcedure);

            var query2 = "SP_Insert_OutgoingItem";
            parameters.Add("@sp_name", itemInVM.Name);
            parameters.Add("@sp_stock", itemInVM.Temp);
            parameters.Add("@sp_info", itemInVM.Information);
            parameters.Add("@sp_date", DateTime.Now);
            parameters.Add("@sp_item_id", Id);
            parameters.Add("@sp_isdelete", false);
            var post2 = _connectionString.Connections.Execute(query2, parameters, commandType: CommandType.StoredProcedure);

            if (post > 0 && post2 > 0)
            {
                return 1;
            }
            return 0;
        }

        public bool Multiple_Delete(int Id)
        {
            var get = "SP_Retrive_Item_ById";
            parameters.Add("@sp_id", Id);
            var get_id = _connectionString.Connections.Query<Item>(get, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

            var query = "SP_Delete_Item";
            parameters.Add("@sp_id", Id);
            parameters.Add("@sp_deletedate", DateTime.Now);
            var post = _connectionString.Connections.Execute(query, parameters, commandType: CommandType.StoredProcedure);

            var query2 = "SP_Insert_OutgoingItem";
            parameters.Add("@sp_name", get_id.Name);
            parameters.Add("@sp_stock", get_id.Stock);
            parameters.Add("@sp_info", get_id.Information);
            parameters.Add("@sp_date", DateTime.Now);
            parameters.Add("@sp_item_id", Id);
            parameters.Add("@sp_isdelete", false);
            var post2 = _connectionString.Connections.Execute(query2, parameters, commandType: CommandType.StoredProcedure);

            if (post > 0 && post2 > 0)
            {
                return true;
            }
            return false;
        }

    }
}
