using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using API_Asset.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client_Asset.Controllers
{
    public class UsersController : Controller
    {
        readonly HttpClient client = new HttpClient();

        public UsersController()
        {
            client.BaseAddress = new Uri("http://192.168.128.79:1708/api/");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(UserVM userVM)
        {
            var myContent = JsonConvert.SerializeObject(userVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var ByteContent = new ByteArrayContent(buffer);
            ByteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var users = client.PostAsync("Users/Login", ByteContent).Result;
            return Json(new { data = users });
        }
    }
}