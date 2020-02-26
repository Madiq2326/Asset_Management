using API_Asset.Models;
using API_Asset.Repositories.Interfaces;
using API_Asset.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.Services
{
    public class ItemService : IItemService
    {
        IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IQueryable<Item> Get()
        {
            var item = _itemRepository.Get();
            if (item != null)
            {
                return item;
            }
            return null;
        }

        public Item Get(int Id)
        {
            var item = _itemRepository.Get(Id);
            if (item != null)
            {
                return item;
            }
            return null;
        }

        public int Post(Item item)
        {
            var post = _itemRepository.Post(item);
            if (post > 0)
            {
                return post;
            }
            return 0;
        }

        public int Put(int Id, Item item)
        {
            var put = _itemRepository.Put(Id, item);
            if (put > 0)
            {
                return put;
            }
            return 0;
        }

        public bool Delete(int Id)
        {
            var delete = _itemRepository.Delete(Id);
            if (delete == true)
            {
                return true;
            }
            return false;
        }
    }
}
