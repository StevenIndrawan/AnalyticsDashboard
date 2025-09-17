using Microsoft.AspNetCore.Mvc;

namespace AnalyticsDashboard.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Demo login sederhana
            if (username == "admin" && password == "123")
            {
                HttpContext.Session.SetString("User", username);
                return RedirectToAction("Index", "Dashboard");
            }

            ViewBag.Error = "Username atau password salah!";
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // hapus session user
            return RedirectToAction("Login");
        }
    }
}
