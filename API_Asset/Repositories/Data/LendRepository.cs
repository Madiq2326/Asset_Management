using API_Asset.Models;
using API_Asset.MyConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using API_Asset.Repositories.Interfaces;
using API_Asset.ViewModels;

namespace API_Asset.Repositories.Data
{
    public class LendRepository : GeneralRepository<Lend>
    {
        public LendRepository(ConnectionString connectionString) : base(connectionString)
        {
        }
    }
}
