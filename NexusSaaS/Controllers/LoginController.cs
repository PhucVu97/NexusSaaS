using Microsoft.AspNetCore.Mvc;

namespace NexusSaaS.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult LoadLoginPartialView()
        {
            return PartialView("LoginPartialView");
        }
    }
}