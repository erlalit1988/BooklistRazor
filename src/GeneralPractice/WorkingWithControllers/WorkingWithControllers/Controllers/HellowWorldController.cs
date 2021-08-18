using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkingWithControllers.Models;

namespace WorkingWithControllers.Controllers
{
    public class HellowWorldController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Greetings = "Hellow World from MVC Core";
            ViewBag.Company = "XYZ";
            ViewBag.Country = "India";

            Authors obj = new();
            obj.Name = "Den";
            obj.Country = "USA";

            return View(obj); //Passing Model data to view
        }

        public IActionResult QueryStringDemo(string message= "Hellow World from MVC Core")
        {
         
            ViewBag.Greetings = message;
          
            return View();
        }
        [HttpGet]
        public IActionResult GetsUrlDemo(string url="https://www.google.com")
        {
            return (Redirect(url));
        }
        [HttpPost]
        public IActionResult GetsUrlDemo(IFormCollection ifc)
        {
            string url = ifc["url"];

            if(url==string.Empty)
            {
                return (Redirect("https://www.google.com"));
            }

            return (Redirect(url));
        }

        
    }
}
