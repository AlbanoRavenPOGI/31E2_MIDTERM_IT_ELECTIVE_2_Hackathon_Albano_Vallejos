using RSVPSystem.Models;

namespace RSVPSystem.Data
{
    public static class DataStore
    {
        public static List<EventModel> Events { get; set; } = new List<EventModel>
        {
            new EventModel
            {
                Id = 1,
                Title = "Sarah & John's Grand Wedding",
                EventType = "Wedding",
                HostName = "Mr. & Mrs. Anderson",
                Venue = "Grand Ballroom, City Hotel",
                FoodMenu = "Buffet Dinner (Steak, Seafood Pasta, Dessert Bar)",
                VisitorCapacity = 150,
                EventDate = DateTime.Today.AddDays(30),
                Description = "Join us in celebrating our special day with dinner and music!"
            }
        };

        public static List<RsvpModel> Rsvps { get; set; } = new List<RsvpModel>
        {
            new RsvpModel { Id = 1, EventId = 1, GuestName = "Alice Smith", Email = "alice@example.com", Status = "Attending", GuestCount = 2 }
        };
    }
}