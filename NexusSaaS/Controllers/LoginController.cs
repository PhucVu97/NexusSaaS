using Microsoft.AspNetCore.Mvc;
using NexusSaaS.Models;
using NexusSaaS.Repository.Interface;
using NexusSaaS.Ultil;

namespace NexusSaaS.Controllers
{
    public class LoginController : Controller
    {
        private ILoginRepository loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }
        public IActionResult LoadLoginPartialView()
        {
            return PartialView("LoginPartialView");
        }

        public IActionResult Login(UserModel user)
        {
            if(user != null)
            {
                if (ModelState.IsValid)
                {
                    loginRepository.Login(user);
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
            return NotFound();
        }
    }
}