using LocalizeCulture.Models;
using LocalizeCulture.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;


namespace LocalizeCulture.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IHtmlLocalizer<HomeController> _localizer;

       private readonly IStringLocalizer<HomeController> _localizer;



        public HomeController(ILogger<HomeController> logger,/*IHtmlLocalizer<HomeController> localizer*/ IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
           // this.localizer = localizer;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            var test = _localizer["HelloWorld"];
            ViewBag.Test = test;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Person person)
        {
          //  string format = "{0:dd/MM/yyyy}";
            Person obj = new();

            obj.FirstName = person.FirstName;
            obj.LastName = person.LastName;
            obj.DateOfBirth = person.DateOfBirth;
           
            
            return View();
        }
        [HttpPost]
        public IActionResult CultureManagement(string culture, string retunUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider
                                                .MakeCookieValue(new RequestCulture(culture)),
                                                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });
            if(string.IsNullOrWhiteSpace(retunUrl))
            {
              

                retunUrl ="~/";
             }
            
            //ViewBag.RetunUrl = Message;
            return LocalRedirect(retunUrl);
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
        public ViewResult RegisterForm()
        {
            return View();
        }
        [HttpPost]
        public ViewResult RegisterForm(WebinarInvites resgistrationResponse)
        {
            if(ModelState.IsValid)
            {
                Repository.AddResponses(resgistrationResponse);
                return View("ThankYou", resgistrationResponse);
            }
            else
            {
                return View();
            }
           
        }

        public ViewResult ListResponses()
        {
            return View(Repository.Response.Where(r => r.WillJoin == true));
        }
    }
}
