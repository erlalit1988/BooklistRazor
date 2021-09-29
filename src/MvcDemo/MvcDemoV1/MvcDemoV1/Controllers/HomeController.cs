using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MvcDemoV1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MvcDemoV1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Category obj = new Category();
       // CountryInfo country = new CountryInfo();
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
        //[HttpGet]
        //public IActionResult CountryIndex()
        //{
        //    country.Countries = CountryList();
        //    ViewBag.Countries =country.Countries;

        //    return View();
        //}
        //public List<SelectListItem> CountryList()
        //{
        //    List<SelectListItem> CultureList = new List<SelectListItem>();

        //    CultureInfo[] getCultureInfos = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

        //    int count = 1;
        //    foreach (CultureInfo cultureInfo in getCultureInfos)
        //    {
        //        RegionInfo regionInfo = new RegionInfo(cultureInfo.LCID);

        //        if (!(CultureList.Distinct())))
        //        {
        //            CultureList.Add(new SelectListItem { Value = count.ToString(), Text = regionInfo.EnglishName });
        //            count++;
        //        }
                
        //    }
        //    CultureList.Sort();

        //    return CultureList;
        //}
        //public List<string> CountryList()
        //{
        //    List<string> CultureList = new List<string>();

        //    CultureInfo[] getCultureInfos = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

        //    foreach (CultureInfo cultureInfo in getCultureInfos)
        //    {
        //        RegionInfo regionInfo = new RegionInfo(cultureInfo.LCID);
        //        if (!(CultureList.Contains(regionInfo.EnglishName)))
        //        {
        //            CultureList.Add(regionInfo.EnglishName);
        //        }
        //    }
        //    CultureList.Sort();
        //    return CultureList;
        //}
        [HttpPost]
        //public IActionResult Index([Bind("Cost,Quantity,CategoryID,ProductName")]Product prod)
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
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();

        }
        [HttpPost]
        public IActionResult SignUp(UserDetails userDetails)
        {
            if(ModelState.IsValid)
            {
                return Content("Success! you can now put data into database...");
            }
            return View();

        }
    }
}
