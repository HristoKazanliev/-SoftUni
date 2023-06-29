using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private IRepository<IRoom> rooms;
        private IRepository<IBooking> bookings;

        public Hotel(string fullName, int category)
        {
            FullName = fullName;
            Category = category;
            rooms = new RoomRepository();
            bookings = new BookingRepository();
        }

        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.HotelNameNullOrEmpty);
                }
                fullName = value;
            }
        }

        public int Category
        {
            get => category;
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);
                }
                category = value;
            }
        }


        public IRepository<IRoom> Rooms
        {
            get => rooms;
            set => rooms = value;
        }

        public IRepository<IBooking> Bookings
        {
            get => bookings;
            set => bookings = value;
        }

        public double Turnover => TotalPaid();

        private double TotalPaid()
        {
            double total = 0;

            foreach (var booking in this.bookings.All())
            {
                total += booking.ResidenceDuration * booking.Room.PricePerNight;
            }

            return Math.Round(total, 2);
        }
    }
}
