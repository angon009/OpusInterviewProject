using Microsoft.AspNetCore.Mvc;

namespace StoreManager.Web.Areas.Manager.Controllers
{
    public class DashboardController : Controller
    {
        [Area("Manager")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
