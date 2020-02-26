using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Client_Asset.Controllers
{
    public class UsersController : Controller
    {
        readonly HttpClient client = new HttpClient();

        public UsersController()
        {
            client.BaseAddress = new Uri("https://localhost:44352/API/");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}