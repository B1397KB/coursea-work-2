using System.ComponentModel.DataAnnotations;

namespace EventApp.Client.Models
{
    // Event model represents an event and basic metadata
    public class EventModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Title { get; set; } = string.Empty;

        public DateTime Date { get; set; } = DateTime.Today;

        public string Location { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Range(0, 10000)]
        public int Capacity { get; set; } = 100;

        // Derived field to track number of registrations
        public int AttendeesCount { get; set; } = 0;
    }
}
