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

        private IHostingEnvironment _hosting;

        public FeaturesController(IFeatureRepository featureRepository, IMapper mapper, IHostingEnvironment hosting)
        {
            this.featureRepository = featureRepository;
            _mapper = mapper;
            _hosting = hosting;
        }
        #endregion

        #region methods CRUD
        // GET: Features
        public IActionResult Index()
        {
            var features = featureRepository.List();
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
                string uploadImgName = "";
                if (feature.Img != null)
                {
                    var uploadFolder = Path.Combine(_hosting.WebRootPath, "images");
                    uploadImgName = Guid.NewGuid() + "_" + feature.Img.FileName;
                    var uploadImgPath = Path.Combine(uploadFolder, uploadImgName);
                    feature.Img.CopyTo(new FileStream(uploadImgPath, FileMode.Create));
                }
                feature.ImgUrl = uploadImgName;
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
                    string uploadImgName = "";
                    if (feature.Img != null)
                    {
                        var uploadFolder = Path.Combine(_hosting.WebRootPath, "images");
                        uploadImgName = Guid.NewGuid() + "_" + feature.Img.FileName;
                        var uploadImgPath = Path.Combine(uploadFolder, uploadImgName);
                        feature.Img.CopyTo(new FileStream(uploadImgPath, FileMode.Create));
                    }
                    feature.ImgUrl = uploadImgName;
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
            var feature = _mapper.Map<FeatureModel>(featureRepository.GetById(id));
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
