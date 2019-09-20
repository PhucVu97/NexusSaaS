using Microsoft.AspNetCore.Mvc;
using NexusSaaS.Models;
using NexusSaaS.Repository.Interface;
using NexusSaaS.Ultil;

namespace NexusSaaS.Controllers
{
    public class LoginController : Controller
    {
        private IUserRepository userRepository;

        public LoginController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public IActionResult LoadLoginPartialView()
        {
            return PartialView("LoginPartialView");
        }

        public IActionResult Login(LoginViewModel loginUser)
        {
            if (loginUser != null)
            {
                if (ModelState.IsValid)
                {
                    var statusCode = userRepository.Login(loginUser);
                    switch (statusCode)
                    {
                        case System.Net.HttpStatusCode.Accepted :
                            return RedirectToAction("Index", "Home");
                        case System.Net.HttpStatusCode.Unauthorized:
                            ModelState.AddModelError("Wrong Password", "Wrong Password");
                            break;
                        case System.Net.HttpStatusCode.NoContent:
                            ModelState.AddModelError("Not Found", "Account doesn't exist");
                            break;
                    }
                }
            }
            return BadRequest();
        }

        public IActionResult Logout()
        {
            var statusCode = userRepository.Logout();
            if(statusCode == System.Net.HttpStatusCode.OK)
            {
                return RedirectToAction("Index", "Home");
            }
            return BadRequest();
        }
    }
}