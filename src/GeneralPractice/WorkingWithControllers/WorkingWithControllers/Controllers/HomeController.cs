using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using WorkingWithControllers.Models;

namespace WorkingWithControllers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHostEnvironment _environment;

        public HomeController(ILogger<HomeController> logger, IHostEnvironment environment)
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
        public ViewResult WishUser(string message = "Default Message")
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
            DateTime mydate = DateTime.ParseExact(ifc["DateOfBirth"], "dd/MM/yyyy", CultureInfo.CurrentCulture);
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
        public RedirectResult GoToURL()
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
        public FileResult DownloadFile()
        {
            return File("/css/site.css", "text/plain", "newwrite.css");
        }
        public FileResult ShowLogo()
        {
            return File("./images/Logo.png", "imgaes/png");
        }
        public FileContentResult DownloadContent()
        {
            var myFile = System.IO.File.ReadAllBytes("./wwwroot/css/site.css");
            return new FileContentResult(myFile, "text/plain");

            //var myFile = System.IO.File.ReadAllBytes("./Data/Products.xml");
            //return new FileContentResult(myFile, "text/xml");
        }
        public FileStreamResult CreateFile()
        {
            var stream = new MemoryStream(Encoding.ASCII.GetBytes("Hello World"));
            return new FileStreamResult(stream, new MediaTypeHeaderValue("text/plain"))
            {
                FileDownloadName = "text.txt"
            };
        }
        public VirtualFileResult VirtualFileResultDemo()
        {
            return new VirtualFileResult("/css/site.css", "text/plain");
        }
        public PhysicalFileResult ShowProducts()
        {
            return new PhysicalFileResult(_environment.ContentRootPath + "/Data/Products.xml", "text/xml");
        }
        public PhysicalFileResult PhysicalFileResultDemo()
        {
            return new PhysicalFileResult(_environment.ContentRootPath + "/wwwroot/css/site.css", "text/plain");
        }
        public JsonResult ShowNewProducts()
        {
            Product prod = new() { ProductCode = 101, ProductName = "Printer", Cost = 1500 };
            return Json(prod);
        }
        public EmptyResult EmptyResultDemo()
        {
            return new EmptyResult();
        }
        public NoContentResult NoContentResultDemo()
        {
            return NoContent();
        }
        public BadRequestResult BRRDemo()
        {
            return BadRequest();
        }
        public StatusCodeResult StatusCodeResultDemo()
        {
            return StatusCode(StatusCodes.Status400BadRequest);

        }
        public BadRequestObjectResult BadRequestObjectResultDemo()
        {
            var modelState = new ModelStateDictionary();
            modelState.AddModelError("br", "Bad Request.");
            return BadRequest(modelState);
        }
        public UnauthorizedResult UnauthorizedResultDemo()
        {
            return Unauthorized();
        }
        public UnauthorizedObjectResult  UnauthorizedObjecResultDemo()
        {
            var modelState = new ModelStateDictionary();
            modelState.AddModelError("br", "You are not authorized to visit this area.");
            
            return Unauthorized(modelState);
        }
        public NotFoundResult NotFoundResultDemo()
        {
            return NotFound();
        }
        public NotFoundObjectResult NotFoundObjectResultDemo()
        {
            return NotFound(new { CutomerId = 1, error = "Not found that CustomerId." });
        }
        public OkObjectResult ReturnOk()
        {
            return Ok(new string[] { "o","k","a","y" });
        }
        public OkObjectResult OkObjectResultDemo()
        {
            return new OkObjectResult(new { Message = "Okay!!" });
        }
        public PartialViewResult showChildViewContent()
        {
            Product prod = new();
            prod.ProductCode = 104;
            prod.ProductName = "Mouse";
            prod.Cost = 1200;
            return PartialView(prod);
        }
    }
}
