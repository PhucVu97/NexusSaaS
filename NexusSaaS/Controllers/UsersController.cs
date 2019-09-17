using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NexusSaaS.Entity;
using NexusSaaS.Models;
using NexusSaaS.Repository.Interface;
using System.Threading.Tasks;

namespace NexusSaaS.Controllers
{
    public class UsersController : Controller
    {
        #region DIs
        private IUserRepository userRepository;
        private IRoleRepository roleRepository;
        private IRoleUser roleUserRepository;
        private readonly IMapper _mapper;


        public UsersController(IUserRepository userRepository, IRoleRepository roleRepository, IRoleUser roleUserRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.roleUserRepository = roleUserRepository;
            _mapper = mapper;
        }
        #endregion

        #region methods CRUD
        // GET: Users
        public async Task<IActionResult> Index()
        {
            var users = userRepository.List();
            return View(users);
        }

        // GET: Users/Details/5
        public IActionResult Details(string id)
        {

            var user = userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            var listRoles = roleRepository.List();
            ViewData["listRoles"] = listRoles;
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserModel user, int[] roleIds)
        {
            if (ModelState.IsValid)
            {
                foreach (var id in roleIds)
                {
                    userRepository.Save(user);
                    var role = roleRepository.GetById(id);
                    RoleUserModel roleUser = new RoleUserModel
                    {
                        Role = _mapper.Map<Role>(role),
                        UserEntity = _mapper.Map<UserEntity>(user),
                    };
                    roleUserRepository.Save(roleUser);       
                }
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public IActionResult Edit(string id)
        {
            var user = userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    userRepository.Update(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var user = userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            userRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
    #endregion
}
