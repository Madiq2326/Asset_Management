using API_Asset.Models;
using API_Asset.MyConnections;
using API_Asset.Repositories.Interfaces;
using API_Asset.ViewModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.Repositories.Data
{
    public class ItemRepository : GeneralRepository<Item>
    {
        public ItemRepository(ConnectionString connectionString) : base(connectionString)
        {

        }


    }
}
