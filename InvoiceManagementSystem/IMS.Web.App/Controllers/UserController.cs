using Microsoft.AspNetCore.Mvc;

namespace IMS.Web.App.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
