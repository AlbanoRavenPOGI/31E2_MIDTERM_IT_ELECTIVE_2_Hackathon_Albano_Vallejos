using System.ComponentModel.DataAnnotations;

namespace RSVPSystem.Models
{
    public class EventModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Event Title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select an event type")]
        public string EventType { get; set; } = "Wedding"; // Wedding, Birthday, Christening

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; } = DateTime.Today;

        public string Description { get; set; } = string.Empty;
    }

    public class RsvpModel
    {
        public int Id { get; set; }
        public int EventId { get; set; }

        [Required(ErrorMessage = "Your name is required")]
        public string GuestName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;

        public string Status { get; set; } = "Attending"; // Attending, Declined, Maybe
        public int GuestCount { get; set; } = 1;
        public DateTime SubmittedAt { get; set; } = DateTime.Now;
    }
}