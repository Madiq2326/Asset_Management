using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.MyConnections
{
    public class ConnectionString : IDisposable
    {
        public MySqlConnection Connections { get; }

        public ConnectionString(string connectionString)
        {
            Connections = new MySqlConnection(connectionString);
            this.Connections.Open();
        }

        public void Dispose()
        {
            Connections.Close();
        }
    }
}
