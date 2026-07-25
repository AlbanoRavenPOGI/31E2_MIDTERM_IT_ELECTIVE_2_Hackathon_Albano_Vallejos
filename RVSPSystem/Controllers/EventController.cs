using Microsoft.AspNetCore.Mvc;
using RSVPSystem.Data;
using RSVPSystem.Models;

namespace RSVPSystem.Controllers
{
    public class EventController : Controller
    {
        // GET: Event/CreateEventPage
        [HttpGet]
        public IActionResult CreateEventPage()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public IActionResult Create(EventModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = DataStore.Events.Count + 1;
                DataStore.Events.Add(model);
                TempData["SuccessMessage"] = "Event created successfully!";
                return RedirectToAction("Dashboard", "Home");
            }
            return View("CreateEventPage", model);
        }

        // GET: Event/RsvpList
        public IActionResult RsvpList()
        {
            var rsvpList = DataStore.Rsvps;
            return View(rsvpList);
        }

        // POST: Submit Guest Response
        [HttpPost]
        public IActionResult SubmitRsvp(RsvpModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = DataStore.Rsvps.Count + 1;
                DataStore.Rsvps.Add(model);
                TempData["SuccessMessage"] = "Thank you for responding!";
                return RedirectToAction("Dashboard", "Home");
            }
            return RedirectToAction("Dashboard", "Home");
        }
    }
}