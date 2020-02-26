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
    public class SuppliersController : ControllerBase
    {
        ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public IQueryable<Supplier> Get()
        {
            var supplier = _supplierService.Get();
            return supplier;
        }

        [HttpGet("{Id}")]
        public ActionResult Get(int Id)
        {
            var supplier = _supplierService.Get(Id);
            if (supplier != null)
            {
                return Ok(supplier);
            }
            return BadRequest();
        }

        [HttpPost]
        public ActionResult Post(Supplier supplier)
        {
            var post = _supplierService.Post(supplier);
            if (post > 0)
            {
                return Ok(post);
            }
            return BadRequest();
        }

        [HttpPut("{Id}")]
        public ActionResult Put(int Id, Supplier supplier)
        {
            var put = _supplierService.Put(Id, supplier);
            if (put > 0)
            {
                return Ok(put);
            }
            return BadRequest();
        }

        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            var delete = _supplierService.Delete(Id);
            if (delete == true)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}