using App.Domain.AppServices;
using App.EndPoint.Mvc.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.EndPoint.Mvc.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SeedData _seedData;

        public HomeController(ILogger<HomeController> logger,
            SeedData seedData)
        {
            _logger = logger;
            _seedData = seedData;
        }

        public async Task<IActionResult> Index()
        {
            await _seedData.Seed();
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