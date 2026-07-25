using Microsoft.AspNetCore.Mvc;

namespace RSVPSystem.Controllers
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
            // Simple validation demo check
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                HttpContext.Session.SetString("User", username);
                return RedirectToAction("Dashboard", "Home");
            }

            ViewBag.Error = "Invalid credentials. Please try again.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}