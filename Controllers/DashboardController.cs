using Microsoft.AspNetCore.Mvc;

namespace AnalyticsDashboard.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            // Jika belum login → redirect ke login
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Login", "Account");
            }

            // Simpan username ke ViewBag supaya bisa dipakai di view
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Role = HttpContext.Session.GetString("Role");

            return View();
        }
    }
}
