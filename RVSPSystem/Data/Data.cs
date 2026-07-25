using RSVPSystem.Models;

namespace RSVPSystem.Data
{
    public static class DataStore
    {
        public static List<EventModel> Events { get; set; } = new List<EventModel>
        {
            new EventModel { Id = 1, Title = "Sarah & John's Wedding", EventType = "Wedding", EventDate = DateTime.Today.AddDays(30), Description = "Join us in celebrating our wedding!" }
        };

        public static List<RsvpModel> Rsvps { get; set; } = new List<RsvpModel>
        {
            new RsvpModel { Id = 1, EventId = 1, GuestName = "Alice Smith", Email = "alice@example.com", Status = "Attending", GuestCount = 2 }
        };
    }
}