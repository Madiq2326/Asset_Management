using API_Asset.Models;
using API_Asset.MyConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.Repositories.Data
{
    public class OutgoingItemRepository : GeneralRepository<OutgoingItem>
    {
        public OutgoingItemRepository(ConnectionString connectionString) : base (connectionString)
        {

        }
    }
}
