using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NwlEmployeeConsole.Bussines;
using NwlEmployeeConsole.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;

namespace NwlEmployeeConsole.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly RenapoInfo renapoInfo = new RenapoInfo();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Search(string wordKey)
        {
            var model = new SearchModel
            {
                WordKey = wordKey
            };

            return View(model);
        }

        [HttpGet]
        public ContentResult RenapoData(string wordKey)
        {

            var renapoInfo = new RenapoInfo();
            var jsonString = renapoInfo.GetData(wordKey);

            return Content(jsonString, "application/json");
        }
            
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
