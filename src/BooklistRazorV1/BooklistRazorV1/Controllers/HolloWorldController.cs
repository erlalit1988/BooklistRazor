using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooklistRazorV1.Controllers
{
    public class HolloWorldController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Greetings = "Hello world from MVC core";
            ViewBag.Company = "Udemy";
            ViewBag.Country = "India";
            return View();
        }
    }
}
