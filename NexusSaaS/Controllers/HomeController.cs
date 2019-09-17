using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NexusSaaS.Entity;
using NexusSaaS.Models;
using NexusSaaS.Repository;
using NexusSaaS.Repository.Interface;
using System.Collections.Generic;
using System.Diagnostics;

namespace NexusSaaS.Controllers
{
    public class HomeController : Controller
    {
        #region DIs
        private IFeatureRepository featureRepository;
        private readonly IMapper _mapper;

        public HomeController(IFeatureRepository featureRepository, IMapper mapper)
        {
            this.featureRepository = featureRepository;
            _mapper = mapper;
        }
        #endregion

        #region methods redirect toi cac trang
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
        #endregion
    }
}
