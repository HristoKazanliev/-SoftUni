using BookingApp.Core.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Bookings;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Bookings.Contracts;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotels;

        public Controller()
        {
            hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            if (hotels.Select(hotelName) != null)
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            Hotel hotel = new Hotel(hotelName, category);
            hotels.AddNew(hotel);
            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {

            //var hotelsList = this.hotels.All().Where(h => h.Category == category).OrderBy(h => h.FullName);

            //if (!hotelsList.Any())
            //{
            //    return String.Format(OutputMessages.CategoryInvalid, category);
            //}

            //var targetHotel = hotelsList.FirstOrDefault(h => h.Rooms.All().Any(r => r.PricePerNight > 0));

            //int guestsCount = adults + children;

            //int bedCapacityLeft = int.MaxValue;
            //foreach (var room in targetHotel.Rooms.All())
            //{
            //    var currentBedCapacityLeft = room.BedCapacity - guestsCount;

            //    if (currentBedCapacityLeft >= 0 && currentBedCapacityLeft < bedCapacityLeft)
            //    {
            //        bedCapacityLeft = currentBedCapacityLeft;
            //    }
            //}

            //IRoom targetRoom = targetHotel.Rooms.All().First(r => r.BedCapacity - guestsCount == bedCapacityLeft);

            //if (targetRoom == null)
            //{
            //    return OutputMessages.RoomNotAppropriate;
            //}

            //IBooking booking = new Booking(targetRoom, duration, adults, children, (targetHotel.Bookings.All().Count + 1));
            //targetHotel.Bookings.AddNew(booking);

            //return string.Format(OutputMessages.BookingSuccessful, booking.BookingNumber, targetHotel.FullName);

            var hotelsList = this.hotels.All().OrderBy(h => h.FullName);

            int guestsCount = adults + children;

            if (hotelsList.Any(h => h.Category == category))
            {
                foreach (var hotel in hotelsList)
                {
                    if (hotel.Category != category)
                    {
                        continue;
                    }

                    var avaliableRoomsList = hotel.Rooms.All()
                        .Where(r => r.PricePerNight > 0)
                        .OrderBy(r => r.BedCapacity);

                    if (avaliableRoomsList.Any(r => r.BedCapacity >= guestsCount))
                    {
                        foreach (var room in avaliableRoomsList)
                        {
                            if (room.BedCapacity >= guestsCount)
                            {
                                // Successful booking
                                int bookingNumber = hotel.Bookings.All().Count + 1;
                                Booking booking = new Booking(room, duration, adults, children, bookingNumber);
                                hotel.Bookings.AddNew(booking);
                                return $"{string.Format(OutputMessages.BookingSuccessful, bookingNumber, hotel.FullName)}";
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            else
            {
                return $"{string.Format(OutputMessages.CategoryInvalid, category)}";
            }

            return OutputMessages.RoomNotAppropriate;
        }

        public string HotelReport(string hotelName)
        {
            var hotel = hotels.Select(hotelName);
            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Hotel name: {hotelName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();
            if (hotel.Bookings.All().Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                foreach (var item in hotel.Bookings.All())
                {
                    sb.AppendLine(item.BookingSummary());
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            var hotel = hotels.Select(hotelName);
            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            IRoom room = null;
            switch (roomTypeName)
            {
                case nameof(DoubleBed):
                    room = new DoubleBed();
                    break;
                case nameof(Studio):
                    room = new Studio();
                    break;
                case nameof(Apartment):
                    room = new Apartment();
                    break;
                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.RoomTypeIncorrect));
            }

            if (hotel.Rooms.GetType().Name == roomTypeName)
            {
                return string.Format(OutputMessages.RoomTypeNotCreated);
            }

            if (room.PricePerNight != 0)
            {
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
            }

            room.SetPrice(price);
            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            var hotel = hotels.Select(hotelName);
            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (hotel.Rooms.All().Any(r => r.GetType().Name == roomTypeName))
            {
                return string.Format(OutputMessages.RoomTypeAlreadyCreated);
            }

            IRoom room=null;
            switch (roomTypeName)
            {
                case nameof(DoubleBed):
                    room = new DoubleBed();
                    break;
                case nameof(Studio):
                    room = new Studio();
                    break;
                case nameof(Apartment):
                    room = new Apartment();
                    break;
                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.RoomTypeIncorrect));
            }

            hotel.Rooms.AddNew(room);
            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }
    }
}
