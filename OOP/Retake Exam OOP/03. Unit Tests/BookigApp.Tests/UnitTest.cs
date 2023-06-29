using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Room roomTest;
        private Hotel hotelTest;

        [SetUp]
        public void Setup()
        {
            roomTest = new Room(3, 10.5);
            hotelTest = new Hotel("hotelTest", 3);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void TestRoomBedCapacityShouldThrowExceptionWhenValueIsNegative(int bedCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Room room = new Room(bedCapacity, 50);
            });
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void TestRoomPricePerNightShouldThrowExceptionWhenValueIsNegative(int pricePerNight)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Room room = new Room(2, pricePerNight);
            });
        }

        [Test]
        public void TestRoomConstructorWorkingCorrectly()
        {
            Room room = new Room(2, 10.50);

            Assert.AreEqual(2, room.BedCapacity);
            Assert.AreEqual(10.50, room.PricePerNight);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void TestNamePropertyShouldThrowExceptionWhenValueIsBNullOrEmpty(string fullName)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Hotel hotel = new Hotel(fullName, 4);
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(6)]
        public void TestCategoryPropertyShouldThrowExceptionWhenValueIsLessThanValidandMoreThanValid(int category)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Hotel hotel = new Hotel("Hotel", category);
            });
        }

        [Test]
        public void TestBookingConstructorWorkingCorrectly()
        {
            Booking booking = new Booking(10, roomTest, 5);

            Assert.AreEqual(10, booking.BookingNumber);
            Assert.AreEqual(3, booking.Room.BedCapacity);
            Assert.AreEqual(10.5, booking.Room.PricePerNight);
            Assert.AreEqual(5, booking.ResidenceDuration);
        }

        [Test]
        public void TestHotelConstructorWorkingCorrectly()
        {
            Assert.AreEqual("hotelTest", hotelTest.FullName);
            Assert.AreEqual(3, hotelTest.Category);
            Assert.AreEqual(0, hotelTest.Turnover);
            Assert.AreEqual(0, hotelTest.Rooms.Count);
            Assert.AreEqual(0, hotelTest.Bookings.Count);
        }

        [Test]
        public void TestAddRoomShouldWorkCorrectly()
        {
            hotelTest.AddRoom(roomTest);

            Assert.AreEqual(1, hotelTest.Rooms.Count);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void TestBookRoomMethodShouldThrowExceptionWithAdults(int adults)
        {
            Assert.Throws<ArgumentException>(() =>
            {
               hotelTest.BookRoom(adults, 2, 5, 300);
            });
        }

        [Test]
        [TestCase(-1)]
        public void TestBookRoomMethodShouldThrowExceptionWithChildren(int children)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                hotelTest.BookRoom(2, children, 5, 300);
            });
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void TestBookRoomMethodShouldThrowExceptionWithresidenceDuration(int residenceDuration)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                hotelTest.BookRoom(2, 1, residenceDuration, 300);
            });
        }

        [Test]
        public void TestBookRoomMethodShouldWorkCorrectly()
        {
            hotelTest.AddRoom(roomTest);
            hotelTest.BookRoom(1, 2, 5, 300);

            Assert.AreEqual(1,hotelTest.Bookings.Count);
            Assert.AreEqual(52.5, hotelTest.Turnover);
        }
    }
}