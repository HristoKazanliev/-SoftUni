using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private readonly List<IRoom> models;

        public RoomRepository()
        {
            models = new List<IRoom>();
        }

        public void AddNew(IRoom model) => models.Add(model);

        public IReadOnlyCollection<IRoom> All()
        {
            IReadOnlyCollection<IRoom> result = this.models;
            return result;
        }


        public IRoom Select(string criteria) => models.FirstOrDefault(m => m.GetType().Name == criteria);

    }
}
