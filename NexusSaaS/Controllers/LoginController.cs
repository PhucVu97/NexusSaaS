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

        public IActionResult Login(UserModel user)
        {
            if (user != null)
            {

                var statusCode = userRepository.Login(user);
                if (statusCode == System.Net.HttpStatusCode.Accepted)
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (statusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    TempData["loginStatus"] = "Wrong password";
                }
                else if (statusCode == System.Net.HttpStatusCode.NoContent)
                {
                    TempData["loginStatus"] = "Account doesn't exist";
                }
            }
            return NotFound();
        }
    }
}