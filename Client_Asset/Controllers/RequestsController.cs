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
    public class RequestsController : Controller
    {
        readonly HttpClient client = new HttpClient();

        public RequestsController()
        {
            client.BaseAddress = new Uri("https://localhost:44352/api/");
        }

        public IActionResult Index()
        {
            ViewBag.Item = List_item();
            ViewBag.Brand = List_brand();
            return View();
        }

        public JsonResult List()
        {
            IEnumerable<Request> request = null;
            var responseTask = client.GetAsync("Requests");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Request>>();
                readTask.Wait();
                request = readTask.Result;
            }
            else
            {
                request = Enumerable.Empty<Request>();
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(new { data = request });
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
            }
            return item;
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
            }
            return brand;
        }

        public JsonResult Create(Request request)
        {
            var myContent = JsonConvert.SerializeObject(request);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var ByteContent = new ByteArrayContent(buffer);
            ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var create = client.PostAsync("Requests/", ByteContent).Result;
            return Json(new { data = create });
        }

        public JsonResult GetById(int Id)
        {
            var cek = client.GetAsync("Requests/" + Id).Result;
            var read = cek.Content.ReadAsAsync<Request>().Result;
            return Json(new { data = read });
        }

        public JsonResult Edit(int Id, Request request)
        {
            var myContent = JsonConvert.SerializeObject(request);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var ByteContent = new ByteArrayContent(buffer);
            ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var update = client.PutAsync("Requests/" + Id, ByteContent).Result;
            return Json(new { data = update });
        }

        public JsonResult Delete(int Id)
        {
            var delete = client.DeleteAsync("Requests/" + Id).ToString();
            return Json(new { data = delete });
        }

        [HttpGet]
        public ActionResult Approve()
        {
            ViewBag.Result = WaitingResult();
            return View();
        }

        [HttpGet]
        public IList<Request> WaitingResult()
        {
            IList<Request> Result = null;
            string Status = "Waiting";
            var responseTask = client.GetAsync("Requests/ " + Status);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Request>>();
                readTask.Wait();
                Result = readTask.Result;
            }
            return Result;
        }
    }
}