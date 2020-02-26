using API_Asset.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.Repositories.Interfaces
{
    public interface IItemRepository
    {
        IQueryable<Item> Get();

        Item Get(int Id);

        int Post(Item item);

        int Put(int Id, Item item);

        bool Delete(int Id);
    }
}
