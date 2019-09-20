using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NexusSaaS.Entity;
using NexusSaaS.Models;
using NexusSaaS.Repository;
using NexusSaaS.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NexusSaaS.Controllers
{
    public class MessagesController : Controller
    {
        #region DIs
        private IMessageRepository messageRepository;

        public MessagesController(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }
        #endregion

        #region methods CRUD
        // GET: Messages
        public async Task<IActionResult> Index()
        {
            var messages = messageRepository.List();
            return View(messages);
        }

        // GET: Messages/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var message = messageRepository.GetById(id);
            if (message == null)
            {
                return NotFound();
            }
            return View(message);
        }

        // GET: Messages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MessageModel message)
        {
            if (ModelState.IsValid)
            {
                messageRepository.Save(message);
                TempData["ProcessMessage"] = "Message sent successful";
            }
            return RedirectToAction("Contact", "Home");
        }

        // GET: Messages/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var message = messageRepository.GetById(id);
            if (message == null)
            {
                return NotFound();
            }
            return View(message);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MessageModel message)
        {
            if (id != message.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    messageRepository.Update(message);
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return RedirectToAction(nameof(Index));
            }
            return View(message);
        }

        // GET: Messages/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var message = messageRepository.GetById(id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            messageRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
    #endregion
}
