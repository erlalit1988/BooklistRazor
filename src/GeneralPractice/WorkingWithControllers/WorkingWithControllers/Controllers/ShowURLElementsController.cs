using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkingWithControllers.Controllers
{
    public class ShowURLElementsController : Controller
    {
        public IActionResult Index()
        {
            var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];
            var id = RouteData.Values["id"];

            var message = $"{controller}::{action}::{id}";
            ViewBag.Message = message;


            return View();
        }
    }
}
