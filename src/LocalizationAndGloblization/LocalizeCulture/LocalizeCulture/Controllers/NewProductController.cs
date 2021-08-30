using LocalizeCulture.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizeCulture.Controllers
{
    public class NewProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        Category objCategory = new Category();

        public NewProductController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Categories = objCategory.Categories;
            return View();
        }


        [HttpPost]
        //public IActionResult Index([Bind("Cost,Quantity,CategoryID,ProductName")] Product prod)
        public IActionResult Index(NProduct prod)
        {
            ViewBag.Categories = objCategory.Categories;
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
    }
}
