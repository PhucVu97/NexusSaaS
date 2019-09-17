using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NexusSaaS.Repository.Interface;

namespace NexusSaaS.Controllers
{
    public class RegisterController : Controller
    {
        private IRoleRepository roleRepository;
        public RegisterController(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }
        public IActionResult LoadRegisterPartialView()
        {
            var listRoles = roleRepository.List();
            ViewData["listRoles"] = listRoles;
            return PartialView("RegisterPartialView");
        }
    }
}