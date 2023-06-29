using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private readonly List<IHotel> models;

        public HotelRepository()
        {
            models = new List<IHotel>();
        }

        public void AddNew(IHotel model) => models.Add(model);
        
        public IReadOnlyCollection<IHotel> All()
        {
            IReadOnlyCollection<IHotel> result = this.models;
            return result;
        }

        public IHotel Select(string criteria) => models.FirstOrDefault(m => m.FullName == criteria);

    }
}
