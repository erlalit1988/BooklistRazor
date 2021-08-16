using Microsoft.AspNetCore.Mvc;
using System;

using LazZiya.ExpressLocalization;



namespace BooklistRazorV1.Controllers
{
   // [Route("{culture}/FirstMVCIntro")]
    public class FirstMVCIntroController : Controller
    {
        //private readonly ISharedCultureLocalizer sharedCulture;

        public FirstMVCIntroController()
        {
           
        }
      //  [HttpGet]
        //[ActionName("index1")]
        public IActionResult Index1()
        {
            return View();
        }
        public string Index2()
        {
            return ("Hello from Index2");
        }
        public ViewResult Index3()
        {
            return View("Index33");
        }
        public ViewResult Index4()
        {
            int hour = DateTime.Now.Hour;
            string viewModel = hour < 12 ? "Good Morning" : "Good Afternoon";
           // return (viewModel);
            return View("Index4",viewModel);
        }
    }
}
