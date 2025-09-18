using Microsoft.AspNetCore.Mvc;

namespace AnalyticsDashboard.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}
