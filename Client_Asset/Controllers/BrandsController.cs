using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using API_Asset.Models;
using Microsoft.AspNetCore.Mvc;

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
            IEnumerable<Brand> departments = null;
            var responsetask = client.GetAsync("Brands");
            responsetask.Wait();
            var result = responsetask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Brand>>();
                readTask.Wait();
                departments = readTask.Result;
            }
            else
            {
                departments = Enumerable.Empty<Brand>();
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(new { data = departments });
        }

        public IList<Brand> List_division()
        {
            IList<Brand> divisions = null;
            var responsetask = client.GetAsync("Brands");
            responsetask.Wait();
            var result = responsetask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Brand>>();
                readTask.Wait();
                divisions = readTask.Result;
                ViewBag.divisions = divisions;
            }
            return ViewBag.divisions;
        }

        public JsonResult Create(Department department)
        {
            var myContent = JsonConvert.SerializeObject(department);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var ByteContent = new ByteArrayContent(buffer);
            ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var departments = client.PostAsync("Departments/", ByteContent).Result;
            return Json(new { data = departments });
        }

        public JsonResult GetById(int Id)
        {
            var cek = client.GetAsync("Departments/" + Id).Result;
            var read = cek.Content.ReadAsAsync<Department>().Result;
            return Json(new { data = read });
        }

        public JsonResult Edit(int Id, Department department)
        {
            var myContent = JsonConvert.SerializeObject(department);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var ByteContent = new ByteArrayContent(buffer);
            ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var update = client.PutAsync("Departments/" + Id, ByteContent).Result;
            return Json(new { data = update });
        }

        public JsonResult Delete(int Id)
        {
            var delete = client.DeleteAsync("Departments/" + Id).ToString();
            return Json(new { data = delete });
        }
    }
}