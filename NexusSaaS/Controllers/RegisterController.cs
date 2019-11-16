using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NexusSaaS.Models;
using NexusSaaS.Repository.Interface;

namespace NexusSaaS.Controllers
{
    public class RegisterController : Controller
    {
        private IRoleRepository roleRepository;
        private IUserRepository userRepository;
        public RegisterController(IRoleRepository roleRepository, IUserRepository userRepository)
        {
            this.roleRepository = roleRepository;
            this.userRepository = userRepository;
        }
        public IActionResult LoadRegisterPartialView()
        {
            var listRoles = roleRepository.List();
            ViewData["listRoles"] = listRoles;
            return PartialView("RegisterPartialView");
        }

        public IActionResult Create([FromBody] UserModel user)
        {
            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    var statusCode = userRepository.Save(user);
                    switch (statusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            TempData["registerStatus"] = "Sign up successfull";
                            return Ok();
                        case System.Net.HttpStatusCode.Conflict:
                            ModelState.AddModelError("Email", "Email Existed");
                            return new JsonResult(ModelState);
                    }
                }
                return new JsonResult(ModelState);
            }
            return NotFound();
        }
    }
}