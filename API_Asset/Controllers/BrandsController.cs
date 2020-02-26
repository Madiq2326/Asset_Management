using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Asset.Models;
using API_Asset.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Asset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public IQueryable<Brand> Get()
        {
            var brand = _brandService.Get();
            return brand;
        }

        [HttpGet("{Id}")]
        public ActionResult Get(int Id)
        {
            var brand = _brandService.Get(Id);
            if (brand != null)
            {
                return Ok(brand);
            }
            return BadRequest();
        }

        [HttpPost]
        public ActionResult Post(Brand brand)
        {
            var post = _brandService.Post(brand);
            if (post > 0)
            {
                return Ok(post);
            }
            return BadRequest();
        }

        [HttpPut("{Id}")]
        public ActionResult Put(int Id,Brand brand)
        {
            var put = _brandService.Put(Id, brand);
            if (put > 0)
            {
                return Ok(put);
            }
            return BadRequest();
        }

        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            var delete = _brandService.Delete(Id);
            if (delete == true)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}