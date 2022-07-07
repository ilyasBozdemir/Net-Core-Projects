using Microsoft.AspNetCore.Mvc;

namespace Web.App.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
