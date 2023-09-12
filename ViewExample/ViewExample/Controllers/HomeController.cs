using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ViewExample.Models;

namespace ViewExample.Controllers
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
            CityWeather city1 = new CityWeather()
            {
                CityUniqueCode = "LDN",
                CityName = "London",
                DateAndTime = DateTime.Now.Date,
                Temperature = 33
            };
            CityWeather city2 = new CityWeather()
            {
                CityUniqueCode = "NYC",
                CityName = "London",
                DateAndTime = DateTime.Now.Date,
                Temperature = 60
            };
            CityWeather city3 = new CityWeather()
            {
                CityUniqueCode = "PAR",
                CityName = "Paris",
                DateAndTime = DateTime.Now.Date,
                Temperature = 80
            };

            List<CityWeather> cityList = new List<CityWeather>();

            cityList.Add(city1);
            cityList.Add(city2);
            cityList.Add(city3);


            return View(cityList);
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