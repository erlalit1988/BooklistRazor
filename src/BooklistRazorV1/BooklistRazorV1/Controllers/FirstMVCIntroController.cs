using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooklistRazorV1.Controllers
{
    public class FirstMVCIntroController : Controller
    {
        public IActionResult Index1()
        {
            return View();
        }
        public string Index2()
        {
            return ("Hello from Index2");
        }
        public ViewResult Index3()
        {
            return View("Index33");
        }
        public ViewResult Index4()
        {
            int hour = DateTime.Now.Hour;
            string viewModel = hour < 12 ? "Good Morning" : "Good Afternoon";
           // return (viewModel);
            return View("Index4",viewModel);
        }
    }
}
