using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcDemoV1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcDemoV1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Category obj = new Category();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Categories = obj.Categories;
            return View();
        }
        [HttpPost]
        public IActionResult Index(Product prod)
        {

            ViewBag.Categories = obj.Categories;
            ModelState.Clear();
            prod.BillAmount = prod.Cost * prod.Quantity;

            if (prod.BillAmount > 10000 && prod.IsPartOfDeal)
            {
                prod.Discount = prod.BillAmount * 10 / 100;
            }
            else
            {
                prod.Discount = prod.BillAmount * 5 / 100;
            }



            prod.NetBillAmount = prod.BillAmount - prod.Discount;

            switch (prod.CategoryID)
            {
                case 1:
                case 2:
                    prod.NetBillAmount -= 1000;
                    break;
            }

            return View(prod);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
