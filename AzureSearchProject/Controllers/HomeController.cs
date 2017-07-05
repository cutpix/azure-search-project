using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FlightSearchProject.Options;
using Microsoft.Extensions.Options;
using FlightSearchProject.Models;

namespace FlightSearchProject.Controllers
{
    public class HomeController : Controller
    {
        public string ApiKey { get; set; }

        public string ServiceName { get; set; }

        public HomeController(IOptions<AppSecrets> optionsAccessor)
        {
            ApiKey = optionsAccessor.Value.SearchApiKey;
            ServiceName = optionsAccessor.Value.SearchServiceName;
        }

        private string[] GetAirportData()
        {
            return new string[]
            {
                "England, London, London Heathrow",
                "United Arab Emirates, Dubai, Dubai International",
                "Japan, Tokyo, Tokyo International",
                "United States, Los Angeles, Los Angeles International",
                "Malaysia, Kuala Lumpur, Kuala Lumpur International",
                "Spain, Madrid, Madrid Barajas International",
                "South Africa, Johannesburg, OR Tambo International",
                "France, Paris, Charles de Gaulle International",
                "Hong Kong, Hong Kong, Hong Kong International",
                "Germany, Frankfurt, Frankfurt am Main International",
                "United States, Miami, Miami International",
                "China, Beijing, Beijing Capital International",
                "Turkey, Ataturk, Atatürk International",
                "Canada, Toronto, Lester B. Pearson International",
                "Austrailia, Sydney, Sydney Kingsford Smith International",
                "Italy, Milan, Leonardo Da Vinci (Fiumicino) International",
                "India, Mumbai, Chhatrapati Shivaji International"
            }; ;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Airports = GetAirportData();
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromBody] Flight flight)
        {
            if (!ModelState.IsValid)
            {
                //handle invalid form submission.
            }

            return NoContent();
        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
