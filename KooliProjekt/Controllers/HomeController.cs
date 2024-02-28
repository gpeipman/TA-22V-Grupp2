using KooliProjekt.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using KooliProjekt.Services;
using KooliProjekt.Data;
using NuGet.Protocol;

namespace KooliProjekt.Controllers
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
            return View();
        }

        /*public async Task<IActionResult> Weather()
        {
            WeatherService service = new WeatherService();
            WeatherForecast forecast = await service.GetData();
            return View(forecast);
        }*/

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