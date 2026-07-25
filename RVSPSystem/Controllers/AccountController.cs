using Microsoft.AspNetCore.Mvc;

namespace RSVPSystem.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Role") == "Admin")
                return RedirectToAction("Dashboard", "Home");

            if (HttpContext.Session.GetString("Role") == "User")
                return RedirectToAction("InvitationList", "Event");

            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "admin123")
            {
                HttpContext.Session.SetString("User", username);
                HttpContext.Session.SetString("Role", "Admin");

                return RedirectToAction("Dashboard", "Home");
            }

            if (username == "user" && password == "user123")
            {
                HttpContext.Session.SetString("User", username);
                HttpContext.Session.SetString("Role", "User");

                return RedirectToAction("InvitationList", "Event");
            }

            ViewBag.Error = "Invalid username or password.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}