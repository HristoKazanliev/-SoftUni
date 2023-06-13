using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;
using TextSplitterApp.Models;
using TextSplitterApp.ViewModels;

namespace TextSplitterApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index(TextViewModel textViewModel)
		{
			return View(textViewModel);
		}

		[HttpPost]
		public IActionResult Split(TextViewModel textViewModel)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("Index", textViewModel);
			}

			var splitTextArr = textViewModel.Text.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

			textViewModel.SplitText = string.Join(Environment.NewLine, splitTextArr);

			return RedirectToAction("Index", textViewModel);
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
	}
}