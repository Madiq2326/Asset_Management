using API_Asset.Models;
using API_Asset.MyConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.Repositories.Data
{
    public class IncomingItemRepository : GeneralRepository<IncomingItem>
    {
        public IncomingItemRepository(ConnectionString connectionString) : base(connectionString)
        {

        }
    }
}
