using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WorkingWithControllers.Models;

namespace WorkingWithControllers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHostEnvironment _environment;

        public HomeController(ILogger<HomeController> logger,IHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
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
        public ViewResult WishUser(string message="Default Message")
        {
            ViewBag.Message = message;
            return View();
        }
        //Get action to display form
        public IActionResult DisplayForm()
        {
            // Create person object
            Person person = new Person { FirstName = "Din", LastName = "Den" };

            //Send model to form
            return View(person);

        }

        //Post action to get Model data as updated from the form
        [HttpPost]
        public IActionResult DisplayForm(IFormCollection ifc)
        {
            //Do whatever you need in your action with recevied data.
            Person obj = new();
            obj.FirstName = ifc["FirstName"];
            obj.LastName = ifc["LastName"];
            DateTime  mydate= DateTime.ParseExact(ifc["DateOfBirth"],"dd/MM/yyyy",CultureInfo.CurrentCulture);
            obj.DateOfBirth = mydate;
            //Here we will display as a string in the browser for the simplicity
            return View(obj);

        }
        public ContentResult GreetUser()
        {
            // return Content("Hellow world From MVC Core");
            // return Content("<div><b>Hellow world From MVC Core</b></div>","text/html");
            //return Content("<div><b>Hellow world From MVC Core</b></div>", "text/xml");
            return Content(_environment.ContentRootPath);
            //return Content(_environment.EnvironmentName);
            //return Content(_environment.WebRootPath);
        }
        public RedirectResult GoToURL( )
        {
            //Http status code:302
            return Redirect("http://www.google.com");
        }

        public RedirectResult GoToURLParmanently()
        {
            //Http status code:301
            return RedirectPermanent("http://www.google.com");
        }

        public RedirectToActionResult GotoContactsAction()
        {
            
            return RedirectToAction("WishUser", new { Message = "I am coming from a different action...." });
        }
        public RedirectToRouteResult GoToAbout()
        {

            return RedirectToRoute("WishUser");
        }
    }
}
