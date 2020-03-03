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
    public class LendsController : Controller
    {
        readonly HttpClient client = new HttpClient();

        public LendsController()
        {
            client.BaseAddress = new Uri("https://localhost:44352/api/");
        }

        public IActionResult Index()
        {
            return View(List_item());
        }

        public JsonResult List()
        {
            IEnumerable<Lend> lend = null;
            var responseTask = client.GetAsync("Lends");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Lend>>();
                readTask.Wait();
                lend = readTask.Result;
            }
            else
            {
                lend = Enumerable.Empty<Lend>();
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(new { data = lend });
        }

        public IList<Item> List_item()
        {
            IList<Item> item = null;
            var responsetask = client.GetAsync("Items");
            responsetask.Wait();
            var result = responsetask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Item>>();
                readTask.Wait();
                item = readTask.Result;
                ViewBag.item = item;
            }
            return ViewBag.item;
        }

        public JsonResult Create(Lend lend)
        {
            var myContent = JsonConvert.SerializeObject(lend);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var ByteContent = new ByteArrayContent(buffer);
            ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var create = client.PostAsync("Lends/", ByteContent).Result;
            return Json(new { data = create });
        }

        public JsonResult GetById(int Id)
        {
            var cek = client.GetAsync("Lends/" + Id).Result;
            var read = cek.Content.ReadAsAsync<Request>().Result;
            return Json(new { data = read });
        }

        public JsonResult Edit(int Id, Lend lend)
        {
            var myContent = JsonConvert.SerializeObject(lend);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var ByteContent = new ByteArrayContent(buffer);
            ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var update = client.PutAsync("Lends/" + Id, ByteContent).Result;
            return Json(new { data = update });
        }

        public JsonResult Delete(int Id)
        {
            var delete = client.DeleteAsync("Lends/" + Id).ToString();
            return Json(new { data = delete });
        }
    }
}