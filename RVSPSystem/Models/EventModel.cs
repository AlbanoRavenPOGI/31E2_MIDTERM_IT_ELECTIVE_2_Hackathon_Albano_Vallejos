using System.ComponentModel.DataAnnotations;

namespace RSVPSystem.Models
{
    public class EventModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Event Title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Event type is required")]
        public string EventType { get; set; } = "Wedding"; // Wedding, Birthday, Christening

        [Required(ErrorMessage = "Host Name is required")]
        public string HostName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Venue/Place is required")]
        public string Venue { get; set; } = string.Empty;

        [Required(ErrorMessage = "Food/Menu details are required")]
        public string FoodMenu { get; set; } = string.Empty;

        [Display(Name = "Expected Visitors")]
        [Range(1, 1000, ErrorMessage = "Please enter a guest count between 1 and 1000")]
        public int VisitorCapacity { get; set; } = 50;

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; } = DateTime.Today.AddDays(7);

        public string Description { get; set; } = string.Empty;

        // Dynamic image handler based on wwwroot/images
        public string ImagePath
        {
            get
            {
                return EventType switch
                {
                    "Wedding" => "/images/wedding.jpg",
                    "Birthday" => "/images/birthday.jpg",
                    "Christening" => "/images/christening.jpg",
                    _ => "/images/default.jpg"
                };
            }
        }
    }

    public class RsvpModel
    {
        public int Id { get; set; }
        public int EventId { get; set; }

        [Required(ErrorMessage = "Your Name is required")]
        public string GuestName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string Status { get; set; } = "Attending"; // Attending, Declined, Maybe

        [Range(1, 10, ErrorMessage = "Guests count must be between 1 and 10")]
        public int GuestCount { get; set; } = 1;

        public DateTime SubmittedAt { get; set; } = DateTime.Now;
    }
}