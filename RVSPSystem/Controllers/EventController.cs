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

<<<<<<< HEAD
                // Direct redirect to the Event details page to view Host, Place, Food & Guest RSVP form!
                return RedirectToAction("Details", new { id = model.Id });
=======
                return RedirectToAction("Dashboard", "Home");
>>>>>>> bb2af7a7b8fb9d8e6a084d6f8c0dc345a16abc6c
            }

            return View("CreateEventPage", model);
        }

<<<<<<< HEAD
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
=======
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

>>>>>>> bb2af7a7b8fb9d8e6a084d6f8c0dc345a16abc6c
        [HttpPost]
        public IActionResult SubmitRsvp(RsvpModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = DataStore.Rsvps.Count + 1;
                model.SubmittedAt = DateTime.Now;
                DataStore.Rsvps.Add(model);
<<<<<<< HEAD
                TempData["SuccessMessage"] = "Thank you! Your RSVP response has been submitted.";
            }
            return RedirectToAction("Details", new { id = model.EventId });
        }

        // GET: Admin Guest RSVP List
        public IActionResult RsvpList()
        {
            return View(DataStore.Rsvps);
=======

                TempData["SuccessMessage"] = "Thank you for responding!";
            }

            return RedirectToAction("Invitation", new { id = model.EventId });
>>>>>>> bb2af7a7b8fb9d8e6a084d6f8c0dc345a16abc6c
        }
    }
}