using API_Asset.Models;
using API_Asset.MyConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using MySql.Data.MySqlClient;
using API_Asset.Repositories.Interfaces;

namespace API_Asset.Repositories.Data
{
    public class RequestRepository : GeneralRepository<Request>
    {
        public RequestRepository(ConnectionString connectionString) : base(connectionString)
        {
        }
    }
}
