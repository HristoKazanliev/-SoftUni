using Homies.Contracts;
using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.EntityFrameworkCore;

namespace Homies.Services
{
    public class EventService : IEventService
    {
        private readonly HomiesDbContext dbContext;

        public EventService(HomiesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllEventViewModel>> GetAllEventsAsync()
        {
            IEnumerable<AllEventViewModel> allEvents = await this.dbContext
                .Events
                .Select(e => new AllEventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString("g"),
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName,
                }).ToArrayAsync();

            return allEvents;
        }

        public async Task<TypeViewModel[]> GetEventTypesAsync()
        {
            var types = await this.dbContext.Types.Select(t => new TypeViewModel
            {
                Id = t.Id,
                Name = t.Name
            }).ToArrayAsync();

            return types;
        }

        public async Task<AddEventViewModel> GetAddEventModelAsync()
        {
            var model = new AddEventViewModel
            {
                Types = await this.GetEventTypesAsync()
            };

            return model;
        }

        public async Task AddEventAsync(AddEventViewModel model, string ownerId)
        {
            Event newEvent = new Event
            {
                Name = model.Name,
                Description = model.Description,
                Start = model.Start,
                End = model.End,
                TypeId = model.TypeId,
                OrganiserId = ownerId,
            };

            await this.dbContext.Events.AddAsync(newEvent);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task JoinEventAsync(int eventId, string userId)
        {
            var joined = await this.dbContext.EventParticipants.AnyAsync(ep => ep.EventId == eventId && ep.HelperId == userId);

            if (joined!)
            {
                throw new InvalidOperationException("Already joined!");
            }

            var newJoinedEvent = new EventParticipant
            {
                HelperId = userId,
                EventId = eventId
            };

            await this.dbContext.EventParticipants.AddAsync(newJoinedEvent);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<AllEventViewModel[]> GetJoinedEventsAsync(string organiserId)
        {
            var events = await this.dbContext.EventParticipants.Where(ep => ep.HelperId == organiserId).Select(ep => new AllEventViewModel
            {
                Id = ep.Event.Id,
                Name = ep.Event.Name,
                Start = ep.Event.Start.ToString("u"),
                Type = ep.Event.Type.Name,
            }).ToArrayAsync();

            return events;
        }

        public async Task LeaveEventAsync(int eventId, string userId)
        {
            var eventToLeave = await this.dbContext.EventParticipants.FirstOrDefaultAsync(ep => ep.EventId == eventId && ep.HelperId == userId);

            if (eventToLeave != null) 
            {
                this.dbContext.EventParticipants.Remove(eventToLeave);

                await this.dbContext.SaveChangesAsync();
            }
        }
    }
}
