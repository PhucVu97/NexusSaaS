using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NexusSaaS.Models;
using NexusSaaS.Repository.Interface;

namespace NexusSaaS.Controllers
{
    public class CategoryController : Controller
    {
        private ICategory categoryRepository;

        public CategoryController(ICategory categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            return View(categoryRepository.List());
        }

        // GET: Categorys/Details/5
        public IActionResult Details(int id)
        {
            var category = categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // GET: Categorys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Save(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categorys/Edit/5
        public IActionResult Edit(int id)
        {

            var category = categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categorys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CategoryModel category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    categoryRepository.Update(category);
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categorys/Delete/5
        public IActionResult Delete(int id)
        {

            var category = categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categorys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            categoryRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}