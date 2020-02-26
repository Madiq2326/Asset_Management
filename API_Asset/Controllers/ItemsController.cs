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
    public class ItemsController : ControllerBase
    {
        IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public IQueryable<Item> Get()
        {
            var item = _itemService.Get();
            return item;
        }

        [HttpGet("{Id}")]
        public ActionResult Get(int Id)
        {
            var item = _itemService.Get(Id);
            if (item != null)
            {
                return Ok(item);
            }
            return BadRequest();
        }

        [HttpPost]
        public ActionResult Post(Item item)
        {
            var post = _itemService.Post(item);
            if (post > 0)
            {
                return Ok(post);
            }
            return BadRequest();
        }

        [HttpPut("{Id}")]
        public ActionResult Put(int Id, Item item)
        {
            var put = _itemService.Put(Id, item);
            if (put > 0)
            {
                return Ok(put);
            }
            return BadRequest();
        }

        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            var delete = _itemService.Delete(Id);
            if (delete == true)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}