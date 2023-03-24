using Microsoft.AspNetCore.Mvc;

namespace AdminSite.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/DashBoard/Index.cshtml");
        }
    }
}
