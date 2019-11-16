using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NexusSaaS.Data;
using NexusSaaS.Entity;
using NexusSaaS.Models;
using NexusSaaS.Repository.Interface;

namespace NexusSaaS.Controllers
{
    public class PostController : Controller
    {
        private IPostRepository postRepository;
        private ICategory categoryRepository;

        public PostController(IPostRepository postRepository, ICategory categoryRepository)
        {
            this.postRepository = postRepository;
            this.categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            return View(postRepository.List());
        }

        // GET: Posts/Details/5
        public IActionResult Details(int id)
        {
            var post = postRepository.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            ViewData["listCategories"] = categoryRepository.List();
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PostViewModel post)
        {
            if (ModelState.IsValid)
            {
                postRepository.Save(post);
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Edit/5
        public IActionResult Edit(int id)
        {

            var post = postRepository.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PostViewModel post)
        {
            if (id != post.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    postRepository.Update(post);
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public IActionResult Delete(int id)
        {

            var post = postRepository.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            postRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
