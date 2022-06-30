using Microsoft.AspNetCore.Mvc;

namespace IMS.Web.App.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
