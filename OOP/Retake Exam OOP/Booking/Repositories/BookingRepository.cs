using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private readonly List<IBooking> models;

        public BookingRepository()
        {
            models = new List<IBooking>();
        }

        public void AddNew(IBooking model) => models.Add(model);

        public IReadOnlyCollection<IBooking> All()
        {
            IReadOnlyCollection<IBooking> result = this.models;
            return result;
        }

        public IBooking Select(string criteria) => models.FirstOrDefault(m => m.BookingNumber.ToString() == criteria);

    }
}
