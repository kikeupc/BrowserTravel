using BrowserTravel.Entidades;
using BrowserTravel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BrowserTravel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BdtravelContext bdtravelContext;

        public HomeController(ILogger<HomeController> logger, BdtravelContext bdtravelContext)
        {
            _logger = logger;
            this.bdtravelContext = bdtravelContext;
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
    }
}