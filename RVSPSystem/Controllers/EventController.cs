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

                // Direct redirect to the Event details page to view Host, Place, Food & Guest RSVP form!
                return RedirectToAction("Details", new { id = model.Id });
            }
            return View("CreateEventPage", model);
        }

        // GET: Public Event Details & Guest RSVP Form
        [HttpGet]
        public IActionResult Details(int id)
        {
            var ev = DataStore.Events.FirstOrDefault(e => e.Id == id) ?? DataStore.Events.FirstOrDefault();
            if (ev == null)
            {
                return RedirectToAction("Dashboard", "Home");
            }

            ViewBag.Rsvps = DataStore.Rsvps.Where(r => r.EventId == ev.Id).ToList();
            return View(ev);
        }

        // POST: Submit Guest RSVP
        [HttpPost]
        public IActionResult SubmitRsvp(RsvpModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = DataStore.Rsvps.Count + 1;
                model.SubmittedAt = DateTime.Now;
                DataStore.Rsvps.Add(model);
                TempData["SuccessMessage"] = "Thank you! Your RSVP response has been submitted.";
            }
            return RedirectToAction("Details", new { id = model.EventId });
        }

        // GET: Admin Guest RSVP List
        public IActionResult RsvpList()
        {
            return View(DataStore.Rsvps);
        }
    }
}