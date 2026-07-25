using Microsoft.AspNetCore.Mvc;
using RSVPSystem.Data;
using RSVPSystem.Models;

namespace RSVPSystem.Controllers
{
    public class EventController : Controller
    {
        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("Role") == "Admin";
        }

        [HttpGet]
        public IActionResult CreateEventPage()
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            return View();
        }

        [HttpPost]
        public IActionResult Create(EventModel model)
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                model.Id = DataStore.Events.Count + 1;
                DataStore.Events.Add(model);

                TempData["SuccessMessage"] = "Event created successfully!";

                return RedirectToAction("Dashboard", "Home");
            }

            return View("CreateEventPage", model);
        }

        public IActionResult RsvpList()
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            return View(DataStore.Rsvps);
        }

        public IActionResult InvitationList()
        {
            return View(DataStore.Events);
        }

        public IActionResult Invitation(int id)
        {
            var invitation = DataStore.Events.FirstOrDefault(x => x.Id == id);

            if (invitation == null)
                return NotFound();

            return View(invitation);
        }

        [HttpPost]
        public IActionResult SubmitRsvp(RsvpModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = DataStore.Rsvps.Count + 1;
                DataStore.Rsvps.Add(model);

                TempData["SuccessMessage"] = "Thank you for responding!";
            }

            return RedirectToAction("Invitation", new { id = model.EventId });
        }
    }
}