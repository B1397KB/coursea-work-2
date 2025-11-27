using EventApp.Client.Models;

namespace EventApp.Client.Services
{
    // In-memory implementation of event and attendance management
    public class EventService : IEventService
    {
        private readonly List<EventModel> _events = new();
        private readonly Dictionary<Guid, List<RegisterModel>> _attendance = new();

        public EventService()
        {
            // Seed sample data
            var e1 = new EventModel { Title = "Intro to Blazor", Date = DateTime.Today.AddDays(7), Location = "Online", Description = "Basics of Blazor", Capacity = 50 };
            var e2 = new EventModel { Title = "Advanced C#", Date = DateTime.Today.AddDays(14), Location = "Room 101", Description = "Deep dive into C# features", Capacity = 30 };
            _events.Add(e1);
            _events.Add(e2);
            _attendance[e1.Id] = new List<RegisterModel>();
            _attendance[e2.Id] = new List<RegisterModel>();
        }

        public Task AddEventAsync(EventModel ev)
        {
            _events.Add(ev);
            _attendance[ev.Id] = new List<RegisterModel>();
            return Task.CompletedTask;
        }

        public Task<EventModel?> GetEventByIdAsync(Guid id)
        {
            return Task.FromResult(_events.FirstOrDefault(e => e.Id == id));
        }

        public Task<IEnumerable<EventModel>> GetEventsAsync()
        {
            return Task.FromResult<IEnumerable<EventModel>>(_events);
        }

        public Task<IEnumerable<RegisterModel>> GetAttendanceAsync(Guid eventId)
        {
            _attendance.TryGetValue(eventId, out var list);
            return Task.FromResult<IEnumerable<RegisterModel>>(list ?? Enumerable.Empty<RegisterModel>());
        }

        public Task<bool> RegisterAttendanceAsync(Guid eventId, RegisterModel registration)
        {
            var ev = _events.FirstOrDefault(e => e.Id == eventId);
            if (ev == null) return Task.FromResult(false);
            var list = _attendance[eventId];
            if (ev.AttendeesCount >= ev.Capacity) return Task.FromResult(false);
            list.Add(registration);
            ev.AttendeesCount = list.Count;
            return Task.FromResult(true);
        }
    }
}
