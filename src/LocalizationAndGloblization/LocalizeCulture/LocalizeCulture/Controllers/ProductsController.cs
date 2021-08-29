using LocalizeCulture.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizeCulture.Controllers
{
    public class ProductsController : Controller
    {
        static List<Product> _product = new()
        {
            new Product
            {
                ProductId = 1,
                ProductName = "AMD Ryzen 3990",
                Quantity = 100,
                UnitsInStock = 50,
                Discontinued = false,
                Cost = 3000,
                LaunchDate = new DateTime(2019, 10, 1,new GregorianCalendar())
            },
            new Product
            {
                ProductId = 2,
                ProductName = "AMD Ryzen 3970",
                Quantity = 100,
                UnitsInStock = 70,
                Discontinued = false,
                Cost = 3000,
                LaunchDate = new DateTime(2019, 10, 5, new GregorianCalendar())
            },
            new Product
            {
                ProductId = 3,
                ProductName = "AMD Ryzen 3960",
                Quantity = 100,
                UnitsInStock = 80,
                Discontinued = false,
                Cost = 3000,
                LaunchDate = new DateTime(2019, 10, 15, new GregorianCalendar())
            },
            new Product
            {
                ProductId = 4,
                ProductName = "AMD Ryzen 3950",
                Quantity = 100,
                UnitsInStock = 50,
                Discontinued = false,
                Cost = 3000,
                LaunchDate = new DateTime(2019, 10, 15, new GregorianCalendar())
            },
        };
        public IActionResult Index()
        {
            return View(_product);
        }
        public IActionResult Details(int id)
        {
            var prod = _product.Find(x => x.ProductId.Equals(id));
            return View(prod);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var prod = _product.Find(x => x.ProductId.Equals(id));
            return View(prod);
        }
        [HttpPost]
        public IActionResult Edit(Product modifiedproduct)
        {
            var prod=_product.FirstOrDefault(x =>x.ProductId==modifiedproduct.ProductId);
            var indexOf = _product.IndexOf(prod);
            _product[indexOf] = modifiedproduct;
            return View("index", _product);
            
           // return View(modifiedproduct);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            var prod = _product.Find(x => x.ProductId.Equals(id));
            return View(prod);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteProduct(int id)
        {

            var prod = _product.Find(x => x.ProductId.Equals(id));
            _product.Remove(prod);
            return View("Index",_product);
        }
        [HttpGet]
        public IActionResult Create()
        {   
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product NewProduct)
        {
            if(ModelState.IsValid)
            {
                NewProduct.Tax = NewProduct.Cost * 10 / 10;
                _product.Add(NewProduct);
                return View("Index", _product);
            }
            else
            {
                return View();

            }
           
        }
    } 
}
