using System.Collections.Generic;
using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NexusSaaS.Data;
using NexusSaaS.Entity;
using NexusSaaS.Models;

namespace NexusSaaS.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<FeatureEntity> featureRepository;
        private readonly IMapper _mapper;

        public HomeController(IRepository<FeatureEntity> featureRepository, IMapper mapper)
        {
            this.featureRepository = featureRepository;
            _mapper = mapper;   
        }

        public IActionResult Index()
        {
            var features = featureRepository.List();
            var featureList = new List<FeatureModel>();
            foreach (var feature in features)
            {
                var model = _mapper.Map<FeatureModel>(feature);
                featureList.Add(model);
            }
            return View(featureList);
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
