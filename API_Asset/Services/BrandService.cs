using API_Asset.Models;
using API_Asset.Repositories.Interfaces;
using API_Asset.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.Services
{
    public class BrandService : IBrandService
    {
        IServiceRepository _brandRepository;

        public BrandService(IServiceRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public IQueryable<Brand> Get()
        {
            var brand = _brandRepository.Get();
            if(brand != null)
            {
                return brand;
            }
            return null;
        }

        public Brand Get(int Id)
        {
            var brand = _brandRepository.Get(Id);
            if(brand != null)
            {
                return brand;
            }
            return null;
        }

        public int Post(Brand brand)
        {
            var post = _brandRepository.Post(brand);
            if (post > 0)
            {
                return post;
            }
            return 0;
        }

        public int Put(int Id, Brand brand)
        {
            var put = _brandRepository.Put(Id, brand);
            if (put > 0)
            {
                return put;
            }
            return 0;
        }

        public bool Delete(int Id)
        {
            var delete = _brandRepository.Delete(Id);
            if (delete == true)
            {
                return true;
            }
            return false;
        }
    }
}
