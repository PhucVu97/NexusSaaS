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
        private IUserRepository userRepository;
        private readonly IMapper _mapper;

        public MessagesController(IMessageRepository messageRepository, IUserRepository userRepository, IMapper mapper)
        {
            this.messageRepository = messageRepository;
            this.userRepository = userRepository;
            _mapper = mapper;
        }
        #endregion

        #region methods CRUD
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
            var listUser = userRepository.List();
            List<UserModel> userModels = new List<UserModel>();
            foreach(var user in listUser)
            {
                var userModel = _mapper.Map<UserModel>(user);
                userModels.Add(userModel);
            }
            ViewData["listUser"] = userModels;
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
                var userModel = userRepository.GetById(message.UserEntityId);
                var userEntity = _mapper.Map<UserEntity>(userModel);
                message.UserEntity = userEntity;
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
    #endregion
}
