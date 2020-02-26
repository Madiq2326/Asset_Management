using API_Asset.Models;
using API_Asset.Repositories.Interfaces;
using API_Asset.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.Services
{
    public class SupplierService : ISupplierService
    {
        ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public IQueryable<Supplier> Get()
        {
            var item = _supplierRepository.Get();
            if (item != null)
            {
                return item;
            }
            return null;
        }

        public Supplier Get(int Id)
        {
            var item = _supplierRepository.Get(Id);
            if (item != null)
            {
                return item;
            }
            return null;
        }

        public int Post(Supplier supplier)
        {
            var post = _supplierRepository.Post(supplier);
            if (post > 0)
            {
                return post;
            }
            return 0;
        }

        public int Put(int Id, Supplier supplier)
        {
            var put = _supplierRepository.Put(Id, supplier);
            if (put > 0)
            {
                return put;
            }
            return 0;
        }

        public bool Delete(int Id)
        {
            var delete = _supplierRepository.Delete(Id);
            if (delete == true)
            {
                return true;
            }
            return false;
        }
    }
}
