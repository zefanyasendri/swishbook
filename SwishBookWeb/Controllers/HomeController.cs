using Microsoft.AspNetCore.Mvc;
using SwishBookWeb.Models;
using System.Diagnostics;

namespace SwishBookWeb.Controllers
{
    // ada di class controller
    public class HomeController : Controller
    {
        // logger : dependency injection
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // action index
        public IActionResult Index()
        {
            return View();
        }

        // action privacy
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