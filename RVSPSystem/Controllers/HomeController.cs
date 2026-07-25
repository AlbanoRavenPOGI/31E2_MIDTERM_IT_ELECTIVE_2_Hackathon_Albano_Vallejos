using Microsoft.AspNetCore.Mvc;

namespace RSVPSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
    }
}