using Microsoft.AspNetCore.Mvc;

namespace IMS.Web.App.Controllers
{
    public class UserPanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
