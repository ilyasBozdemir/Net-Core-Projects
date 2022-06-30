using Microsoft.AspNetCore.Mvc;

namespace IMS.Web.App.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
