using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewComponentDemo.Models;

namespace ViewComponentDemo.Controllers
{
    public class ProductInTagDemoController : Controller
    {
        private readonly ProductsData productsData;

        public ProductInTagDemoController(ProductsData productsData)
        {
            this.productsData = productsData;
        }
        public IActionResult Index()
        {
            return View(productsData.Products);
        }
        public IActionResult Details(int id)
        {
            return View(productsData.Products.FirstOrDefault(a => a.ProductID == id));
        }
        [Route("/ProductInTagDemo/ShowAllProducts",Name ="ListOfProducts")]
        public IActionResult ShowAllProducts()
        {
            return View(productsData.Products);
        }
    }
}
