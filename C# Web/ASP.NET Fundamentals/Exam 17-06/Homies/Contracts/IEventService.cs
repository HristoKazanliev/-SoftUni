using Homies.Models;

namespace Homies.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<AllEventViewModel>> GetAllEventsAsync();

        Task<TypeViewModel[]> GetEventTypesAsync();

        Task<AddEventViewModel> GetAddEventModelAsync();

        Task AddEventAsync(AddEventViewModel model, string ownerId);

        Task JoinEventAsync(int eventId, string userId);

        Task<AllEventViewModel[]> GetJoinedEventsAsync(string organiserId);

        Task LeaveEventAsync(int eventId, string userId);

        Task<AddEventViewModel> GetEditAsync(int eventId);

        Task UpdateEventAsync(AddEventViewModel model);
    }
}
