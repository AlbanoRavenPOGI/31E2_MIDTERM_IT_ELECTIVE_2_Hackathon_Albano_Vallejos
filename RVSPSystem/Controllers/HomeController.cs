using Microsoft.AspNetCore.Mvc;

namespace RSVPSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}