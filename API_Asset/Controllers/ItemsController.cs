using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Asset.Bases;
using API_Asset.Models;
using API_Asset.Repositories.Data;
using API_Asset.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Asset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : BasesController<Item, ItemRepository>
    {
        private readonly ItemRepository _itemRepository;

        public ItemsController(ItemRepository itemRepository) : base(itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet("List_Item")]
        public ActionResult Get_List()
        {
            var getlist = _itemRepository.Get_List();
            return Ok(getlist);
        }

        [HttpPost("Post_InOut")]
        public ActionResult Multiple_Post(ItemInVM itemInVM)
        {
            itemInVM.Create();
            var create = _itemRepository.Multiple_Post(itemInVM);
            if (create > 0)
            {
                return Ok(create + " data has been created");
            }
            return BadRequest();
        }

        [HttpPut("Update_InOut/{Id}")]
        public ActionResult Put(int Id, ItemInVM itemInVM)
        {
            var get = _itemRepository.Get(Id);
            var read = get.Result.Stock;
            itemInVM.Update();

            if (read < itemInVM.Stock)
            {
                itemInVM.Temp = itemInVM.Stock - read;
                var put_in = _itemRepository.Update_In(Id, itemInVM);
                if (put_in > 0)
                {
                    return Ok("Update Success In");
                }
            }
            else if (read > itemInVM.Stock)
            {
                itemInVM.Temp = read - itemInVM.Stock;
                var put_out = _itemRepository.Update_Out(Id, itemInVM);
                if (put_out > 0)
                {
                    return Ok("Update Success Out");
                }
            }
            return BadRequest("Update Failed");
        }

        [HttpDelete("Delete_InOut/{Id}")]
        public ActionResult Delete(int Id)
        {
            var delete = _itemRepository.Multiple_Delete(Id);
            if (delete == true)
            {
                return Ok("Soft Delete Success");
            }
            return BadRequest("Soft Delete Failed");
        }
    }
}