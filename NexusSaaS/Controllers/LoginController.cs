using Microsoft.AspNetCore.Mvc;
using NexusSaaS.Models;
using NexusSaaS.Repository.Interface;

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

        public IActionResult ForgotPassword()
        {
            return View("Views/Home/ForgotPassword.cshtml");
        }

        [HttpPost]
        public IActionResult ForgotPassword(string email)
        {
            var statusCode = userRepository.ResetPasswordUrl(email);
            switch (statusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    TempData["resetStatus"] = "Check Email for reset url";
                    return RedirectToAction("ForgotPassword", "Login");
                case System.Net.HttpStatusCode.InternalServerError:
                    TempData["resetStatus"] = "Error";
                    return RedirectToAction("ForgotPassword", "Login");
                case System.Net.HttpStatusCode.NotFound:
                    TempData["resetStatus"] = "Account does not exist";
                    return RedirectToAction("ForgotPassword", "Login");
            }
            return BadRequest();
        }

        public IActionResult ResetPassword(string AccessToken)
        {
            var resetModel = new ResetPasswordModel();
            resetModel.Token = AccessToken;
            return View("Views/Home/ResetPassword.cshtml", resetModel);
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordModel resetPassword)
        {
            var statusCode = userRepository.ResetPassword(resetPassword);
            switch (statusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    TempData["resetStatus"] = "Password Reset";
                    return RedirectToAction("ResetPassword", "Login");
                case System.Net.HttpStatusCode.BadRequest:
                    TempData["resetStatus"] = "Request Expired";
                    return RedirectToAction("ResetPassword", "Login");
            }
            return BadRequest();
        }
    }
}