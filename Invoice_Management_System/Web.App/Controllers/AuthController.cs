using Microsoft.AspNetCore.Mvc;

namespace Web.App.Controllers
{
    public class AuthController : BaseController
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
