using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NexusSaaS.Data;
using NexusSaaS.Models;

namespace NexusSaaS.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<FeatureModel> featureRepository;
        public HomeController(IRepository<FeatureModel> featureRepository)
        {
            this.featureRepository = featureRepository;
        }

        public IActionResult Index()
        {
            var features = featureRepository.List();
            return View(features);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Pricing()
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
