using ASPNETCoreDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPNETCoreDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {   
            //ViewBag - random data using dynamic object
            //ViewData - random data using dictionary
            ViewBag.Msg = "Hello World from ViewBag";
            ViewData["Message"] = "Hello World from ViewData!";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "This is an ASP .NET Core MVC app.";

            return View();
        }

        public IActionResult Numbers() 
        {
            return View();
        }

        public IActionResult NumbersToN(int count = 0)
        {
			ViewBag.Count = count;

			return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}