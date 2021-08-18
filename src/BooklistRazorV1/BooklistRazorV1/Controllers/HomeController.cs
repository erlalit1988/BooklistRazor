using BooklistRazorV1.Models;
using LazZiya.ExpressLocalization;
using LazZiya.TagHelpers.Alerts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BooklistRazorV1.Controllers
{
    //[Route("{culture}/Home")]
    public class HomeController : FirstMVCIntroController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISharedCultureLocalizer sharedCulture;

        public HomeController(ILogger<HomeController> logger, ISharedCultureLocalizer sharedCulture)
        {
            _logger = logger;
            this.sharedCulture = sharedCulture;
        }

        public IActionResult Index()
        {
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
            DateTime mydate = DateTime.ParseExact(ifc["DateOfBirth"], "dd/MM/yyyy", CultureInfo.CurrentCulture);
            obj.DateOfBirth = mydate;
            //Here we will display as a string in the browser for the simplicity
            return View(obj);

        }
        public IActionResult Privacy()
        {
           
            var msg = sharedCulture.GetLocalizedString("Privacy Policy");

           
            TempData.Warning(msg.ToString());

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
        public IActionResult OnGetSetCultureCookie(string cltr, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cltr)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

            return LocalRedirect(returnUrl);
        }
    }
}
