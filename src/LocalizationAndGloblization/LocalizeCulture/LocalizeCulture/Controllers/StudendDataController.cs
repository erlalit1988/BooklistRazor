using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizeCulture.Controllers
{
    public class StudendDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
