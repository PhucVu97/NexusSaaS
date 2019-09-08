using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NexusSaaS.Data;
using NexusSaaS.Models;

namespace NexusSaaS.Controllers
{
    public class FeaturesController : Controller
    {
        private IRepository<FeatureModel> featureRepository;

        public FeaturesController(IRepository<FeatureModel> featureRepository)
        {
            this.featureRepository = featureRepository;
        }

        // GET: Features
        public async Task<IActionResult> Index()
        {
            return View(featureRepository.List());
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
                return RedirectToAction(nameof(Index));
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
            return View(feature);
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
            if (id == null)
            {
                return NotFound();
            }

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
}
