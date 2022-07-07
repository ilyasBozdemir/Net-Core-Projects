using Microsoft.AspNetCore.Mvc;

namespace Web.App.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
