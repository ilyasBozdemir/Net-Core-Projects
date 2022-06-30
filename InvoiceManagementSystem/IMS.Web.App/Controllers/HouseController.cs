using Microsoft.AspNetCore.Mvc;

namespace IMS.Web.App.Controllers
{
    public class HouseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
