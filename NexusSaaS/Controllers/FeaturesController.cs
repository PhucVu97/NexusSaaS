using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NexusSaaS.Models;
using NexusSaaS.Repository.Interface;
using System;
using System.IO;
using System.Threading.Tasks;

namespace NexusSaaS.Controllers
{
    public class FeaturesController : Controller
    {
        #region DIs
        private IFeatureRepository featureRepository;
        private readonly IMapper _mapper;


        public FeaturesController(IFeatureRepository featureRepository, IMapper mapper)
        {
            this.featureRepository = featureRepository;
            _mapper = mapper;
        }
        #endregion

        #region methods CRUD
        // GET: Features
        public IActionResult Index(int page, int pageSize)
        {
            var features = featureRepository.PagedList(page, pageSize);
            return View(features);
        }

        // GET: Features/Details/5
        public IActionResult Details(int id)
        {

            var feature = featureRepository.GetById(id);
            if (feature == null)
            {
                return NotFound();
            }
            return View(feature);
        }

        // GET: Features/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Features/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FeatureModel feature)
        {
            if (ModelState.IsValid)
            {
                featureRepository.Save(feature);
            }
            return View(feature);
        }

        // GET: Features/Edit/5
        public IActionResult Edit(int id)
        {
            var feature = featureRepository.GetById(id);
            if (feature == null)
            {
                return NotFound();
            }

            var featureModel = _mapper.Map<FeatureModel>(feature);
            return View(featureModel);
        }

        // POST: Features/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FeatureModel feature)
        {
            if (id != feature.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    featureRepository.Update(feature);
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return RedirectToAction(nameof(Index));
            }
            return View(feature);
        }

        // GET: Features/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var feature = featureRepository.GetById(id);
            if (feature == null)
            {
                return NotFound();
            }

            return View(feature);
        }

        // POST: Features/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            featureRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
    #endregion
}
