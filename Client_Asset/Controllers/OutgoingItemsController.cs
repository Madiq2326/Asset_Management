using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using API_Asset.Models;
using Microsoft.AspNetCore.Mvc;

namespace Client_Asset.Controllers
{
    public class OutgoingItemsController : Controller
    {
        readonly HttpClient client = new HttpClient();

        public OutgoingItemsController()
        {
            client.BaseAddress = new Uri("https://localhost:44352/api/");
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            IEnumerable<OutgoingItem> item = null;
            var responsetask = client.GetAsync("OutgoingItems");
            responsetask.Wait();
            var result = responsetask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<OutgoingItem>>();
                readTask.Wait();
                item = readTask.Result;
            }
            else
            {
                item = Enumerable.Empty<OutgoingItem>();
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(new { data = item });
        }
    }
}