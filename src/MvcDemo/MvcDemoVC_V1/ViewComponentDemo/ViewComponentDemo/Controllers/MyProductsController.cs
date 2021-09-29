using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewComponentDemo.Models;

namespace ViewComponentDemo.Controllers
{
    [ViewComponent(Name ="ProductControllerHybrid")]
    public class MyProductsController : Controller
    {
        private readonly ProductsData pdata;

        public MyProductsController(ProductsData pdata)
        {
            this.pdata = pdata;
        }
        public IActionResult Index()
        {
            return View(pdata.Products);
        }
        public IViewComponentResult Invoke(int Units)
        {

            return new ViewViewComponentResult()
            {
                ViewData = new ViewDataDictionary<ProductViewModel>(
                    ViewData,
                    new ProductViewModel
                    {
                        ProductsCount = pdata.Products.Where(n => n.UnitsInStock >= Units).Count(),
                        StockWorth = pdata.Products.Where(n => n.UnitsInStock >= Units).Sum(c => c.Cost)
                    })
            };
           
        }
    }
}
