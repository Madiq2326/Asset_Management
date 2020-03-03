using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using API_Asset.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client_Asset.Controllers
{
    public class SuppliersController : Controller
    {
        readonly HttpClient client = new HttpClient();

        public SuppliersController()
        {
            client.BaseAddress = new Uri("https://localhost:44352/api/");
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            IEnumerable<Supplier> supplier = null;
            var responsetask = client.GetAsync("Suppliers");
            responsetask.Wait();
            var result = responsetask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();
                supplier = readTask.Result;
            }
            else
            {
                supplier = Enumerable.Empty<Supplier>();
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(new { data = supplier });
        }

        public JsonResult Create(Supplier supplier)
        {
            var myContent = JsonConvert.SerializeObject(supplier);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var ByteContent = new ByteArrayContent(buffer);
            ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var create = client.PostAsync("Suppliers/", ByteContent).Result;
            return Json(new { data = create });
        }

        public JsonResult GetById(int Id)
        {
            var cek = client.GetAsync("Suppliers/" + Id).Result;
            var read = cek.Content.ReadAsAsync<Supplier>().Result;
            return Json(new { data = read });
        }

        public JsonResult Edit(int Id, Supplier supplier)
        {
            var myContent = JsonConvert.SerializeObject(supplier);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var ByteContent = new ByteArrayContent(buffer);
            ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var update = client.PutAsync("Suppliers/" + Id, ByteContent).Result;
            return Json(new { data = update });
        }

        public JsonResult Delete(int Id)
        {
            var delete = client.DeleteAsync("Suppliers/Delete/" + Id).ToString();
            return Json(new { data = delete });
        }
    }
}