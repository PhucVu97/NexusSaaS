using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NexusSaaS.Data;
using NexusSaaS.Entity;
using NexusSaaS.Models;

namespace NexusSaaS.Controllers
{
    public class MessagesController : Controller
    {
        private IRepository<MessageEntity> messageRepository;
        private readonly IMapper _mapper;

        public MessagesController(IRepository<MessageEntity> messageRepository, IMapper mapper)
        {
            this.messageRepository = messageRepository;
            _mapper = mapper;
        }

        // GET: Messages
        public async Task<IActionResult> Index()
        {
            var messages = messageRepository.List();
            var messagesList = new List<MessageModel>();
            foreach (var message in messages)
            {
                var model = _mapper.Map<MessageModel>(message);
                messagesList.Add(model);
            }
            return View(messagesList);
        }

        // GET: Messages/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var message = messageRepository.GetById(id);
            if (message == null)
            {
                return NotFound();
            }

            var messageModel = _mapper.Map<MessageModel>(message);

            return View(messageModel);
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
                var messageEntity = _mapper.Map<MessageEntity>(message);
                messageRepository.Save(messageEntity);
            }
            return View(message);
        }

        // GET: Messages/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var message = messageRepository.GetById(id);
            if (message == null)
            {
                return NotFound();
            }

            var messageModel = _mapper.Map<MessageModel>(message);
            return View(messageModel);
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
                    var messageEntity = _mapper.Map<MessageEntity>(message);
                    messageRepository.Update(messageEntity);
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

            var message = _mapper.Map<MessageModel>(messageRepository.GetById(id));
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
}
