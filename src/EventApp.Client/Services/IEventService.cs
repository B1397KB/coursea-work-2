using EventApp.Client.Models;

namespace EventApp.Client.Services
{
    public interface IEventService
    {
        Task<IEnumerable<EventModel>> GetEventsAsync();
        Task<EventModel?> GetEventByIdAsync(Guid id);
        Task AddEventAsync(EventModel ev);
        Task<bool> RegisterAttendanceAsync(Guid eventId, RegisterModel registration);
        Task<IEnumerable<RegisterModel>> GetAttendanceAsync(Guid eventId);
    }
}
