using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using API_Asset.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client_Asset.Controllers
{
    public class UsersController : Controller
    {
        readonly HttpClient client = new HttpClient();

        public UsersController()
        {
            client.BaseAddress = new Uri("http://192.168.128.233:1708/");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE1ODUyNzQwNDEsImlzcyI6ImJvb3RjYW1wcmVzb3VyY2VtYW5hZ2VtZW50IiwiYXVkIjoicmVhZGVycyJ9.YA-M_KN25FWmUuIS1bd9F5ioiRkVY8NCas1Bjma8kjQ");
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
            var users = client.PostAsync("Login", ByteContent).Result;
            if (users.IsSuccessStatusCode)
            {
                var read = users.Content.ReadAsStringAsync().Result.Replace("\"", "").Split("...");
                var token = "Bearer " + read[0];
                var username = read[1];
                HttpContext.Session.SetString("Token", token);
                HttpContext.Session.SetString("Username", username);
                return Json(new { data = read, users.StatusCode });
            }
            return Json(new { users.StatusCode });
        }
    }
}