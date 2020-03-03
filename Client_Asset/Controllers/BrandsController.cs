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
    public class BrandsController : Controller
    {
        readonly HttpClient client = new HttpClient();

        public BrandsController()
        {
            client.BaseAddress = new Uri("https://localhost:44352/api/");
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            IEnumerable<Brand> brand = null;
            var responsetask = client.GetAsync("Brands");
            responsetask.Wait();
            var result = responsetask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Brand>>();
                readTask.Wait();
                brand = readTask.Result;
            }
            else
            {
                brand = Enumerable.Empty<Brand>();
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(new { data = brand });
        }

        public JsonResult Create(Brand brand)
        {
            var myContent = JsonConvert.SerializeObject(brand);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var ByteContent = new ByteArrayContent(buffer);
            ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var create = client.PostAsync("Brands/", ByteContent).Result;
            return Json(new { data = create });
        }

        public JsonResult GetById(int Id)
        {
            var cek = client.GetAsync("Brands/" + Id).Result;
            var read = cek.Content.ReadAsAsync<Brand>().Result;
            return Json(new { data = read });
        }

        public JsonResult Edit(int Id, Brand brand)
        {
            var myContent = JsonConvert.SerializeObject(brand);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var ByteContent = new ByteArrayContent(buffer);
            ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var update = client.PutAsync("Brands/" + Id, ByteContent).Result;
            return Json(new { data = update });
        }

        public JsonResult Delete(int Id)
        {
            var delete = client.DeleteAsync("Brands/Delete/" + Id).ToString();
            return Json(new { data = delete });
        }
    }
}