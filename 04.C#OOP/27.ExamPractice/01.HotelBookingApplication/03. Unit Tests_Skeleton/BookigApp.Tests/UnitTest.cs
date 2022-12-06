using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Linq;

namespace BookigApp.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorSetsHotelNameProperly()
        {
            Hotel hotel = new Hotel("PRH", 3);
            Assert.AreEqual("PRH", hotel.FullName);
        }

        [Test]
        public void ConstructorSetsCategoryProperly()
        {
            Hotel hotel = new Hotel("PRH", 3);
            Assert.AreEqual(3, hotel.Category);
        }

        [Test]
        public void ConstructorInitializesRoom()
        {
            Hotel hotel = new Hotel("PRH", 3);
            Assert.AreEqual(0, hotel.Rooms.Count);
        }

        [Test]
        public void ConstructorInitializesBookings()
        {
            Hotel hotel = new Hotel("PRH", 3);
            Assert.AreEqual(0, hotel.Bookings.Count);
        }

        [Test]
        public void EmptyHotelNameShouldThrowException()
        {
            Hotel hotel;
            Assert.Throws<ArgumentNullException>(() =>
            hotel = new Hotel("", 3)
            );
        }

        [Test]
        public void CategoryLessThan1ShouldThrowException()
        {
            Hotel hotel;
            Assert.Throws<ArgumentException>(() =>
            hotel = new Hotel("PRH", 0)
            );
        }

        [Test]
        public void CategoryMoreThan5ShouldThrowException()
        {
            Hotel hotel;
            Assert.Throws<ArgumentException>(() =>
            hotel = new Hotel("PRH", 6)
            );
        }

        [Test]
        public void TurnoverReturns0ByDefault()
        {
            Hotel hotel = new Hotel("PRH", 3);
            Assert.AreEqual(0, hotel.Turnover);
        }

        [Test]
        public void TurnoverReturnsProperValue()
        {
            Hotel hotel = new Hotel("PRH", 3);
            Room room = new Room(5, 33);
            hotel.AddRoom(room);
            hotel.BookRoom(3, 1, 2, 100);
            Assert.AreEqual(66, hotel.Turnover);
        }

        [Test]
        public void RoomsReturnsProperRoom()
        {
            Hotel hotel = new Hotel("PRH", 3);
            Room room = new Room(5, 33);
            hotel.AddRoom(room);
            Assert.AreEqual(room, hotel.Rooms.FirstOrDefault(x => x.BedCapacity == 5));
        }

        [Test]
        public void AddRoomAddsRoom()
        {
            Hotel hotel = new Hotel("PRH", 3);
            Room room = new Room(5, 33);
            hotel.AddRoom(room);
            Assert.AreEqual(1, hotel.Rooms.Count);
        }

        [TestCase(-2, 2, 2)]
        [TestCase(0, 2, 2)]
        [TestCase(2, -2, 2)]
        [TestCase(2, 2, 0)]
        public void BookingWithNegativeDataShouldThrowException(int adults, int children, int duration)
        {
            Hotel hotel = new Hotel("PRH", 3);
            Room room = new Room(5, 33);
            hotel.AddRoom(room);
            Assert.Throws<ArgumentException>(() =>
            hotel.BookRoom(adults, children, duration, 200)
            );
        }

        [Test]
        public void BookingWithProperDataMakesANewBooking()
        {
            Hotel hotel = new Hotel("PRH", 3);
            Room room = new Room(5, 33);
            hotel.AddRoom(room);
            hotel.BookRoom(3, 1, 2, 100);
            Assert.AreEqual(1, hotel.Bookings.FirstOrDefault(x => x.BookingNumber == 1).BookingNumber);
        }
    }
}