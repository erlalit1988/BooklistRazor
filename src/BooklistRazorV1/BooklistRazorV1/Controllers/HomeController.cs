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
using System.Linq;
using System.Threading.Tasks;

namespace BooklistRazorV1.Controllers
{
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

        public IActionResult Privacy()
        {
            // This is a sample to show how to localize 
            // custom messages from the backend.
            // The texts must be defined in ViewsLocalizationResource.xx.resx
            var msg = sharedCulture.GetLocalizedString("Privacy Policy");

            // Use AlertTagHelper to show messages
            // Available options : .Success .Warning .Danger .Info .Dark .Light .Primary .Secondary
            // For more details visit: http://demo.ziyad.info/alert
            TempData.Warning(msg);

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
