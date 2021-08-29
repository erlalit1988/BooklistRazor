using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizeCulture.Controllers
{
    public class StateDemoController : Controller
    {

        public IActionResult Index()
        {
            ViewData["Ecode"] = "101";
            ViewData["Ename"] = "Connors";

            ViewBag.Message = "This is coming from ViewBag.Message";

            TempData.Add("Country", "India");
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormCollection ifc)
        {
            return View();
        }
       
    }
}
