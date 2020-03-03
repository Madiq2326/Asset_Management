using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using API_Asset.Models;
using API_Asset.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client_Asset.Controllers
{
    public class ItemsController : Controller
    {
        readonly HttpClient client = new HttpClient();

        public ItemsController()
        {
            client.BaseAddress = new Uri("https://localhost:44352/api/");
        }

        public IActionResult Index()
        {
            ViewBag.brand = List_brand();
            ViewBag.supplier = List_supplier();
            return View();
        }

        public JsonResult List()
        {
            IEnumerable<Item> item = null;
            var responsetask = client.GetAsync("Items");
            responsetask.Wait();
            var result = responsetask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Item>>();
                readTask.Wait();
                item = readTask.Result;
            }
            else
            {
                item = Enumerable.Empty<Item>();
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(new { data = item });
        }

        public IList<Brand> List_brand()
        {
            IList<Brand> brand = null;
            var responsetask = client.GetAsync("Brands");
            responsetask.Wait();
            var result = responsetask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Brand>>();
                readTask.Wait();
                brand = readTask.Result;
                return ViewBag.brand = brand;
            }
            return ViewBag.brand = brand;
        }

        public IList<Supplier> List_supplier()
        {
            IList<Supplier> supplier = null;
            var responsetask = client.GetAsync("Suppliers");
            responsetask.Wait();
            var result = responsetask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();
                supplier = readTask.Result;
                return ViewBag.supplier = supplier;
            }
            return ViewBag.supplier = supplier;
        }

        public JsonResult Create(Item item)
        {
            var myContent = JsonConvert.SerializeObject(item);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var ByteContent = new ByteArrayContent(buffer);
            ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var create = client.PostAsync("Items/Post_InOut", ByteContent).Result;
            return Json(new { data = create });
        }

        public JsonResult GetById(int Id)
        {
            var cek = client.GetAsync("Items/" + Id).Result;
            var read = cek.Content.ReadAsAsync<Item>().Result;
            return Json(new { data = read });
        }

        public JsonResult Edit(int Id, Item item)
        {
            var myContent = JsonConvert.SerializeObject(item);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var ByteContent = new ByteArrayContent(buffer);
            ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var update = client.PutAsync("Items/" + Id, ByteContent).Result;
            return Json(new { data = update });
        }

        public JsonResult Delete(int Id)
        {
            var delete = client.DeleteAsync("Items/Delete_InOut/" + Id).ToString();
            return Json(new { data = delete });
        }

        public JsonResult Edit_In_Out(int Id, ItemInVM item)
        {
            var myContent = JsonConvert.SerializeObject(item);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var ByteContent = new ByteArrayContent(buffer);
            ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var update = client.PutAsync("Items/Update_InOut/" + Id, ByteContent).Result;
            return Json(new { data = update });
        }
    }
}