namespace BookingApp.Models.Hotels
{
    using System;
    using System.Linq;

    using Contacts;
    using Bookings.Contracts;
    using Rooms.Contracts;
    using Repositories.Contracts;
    using Utilities.Messages;
    using BookingApp.Repositories;

    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private RoomRepository rooms;
        private BookingRepository bookings;

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
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
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

        public double Turnover
        {
            get
            {
                double sum = 0;
                bookings.All().Sum(x => sum+= (x.ResidenceDuration * x.Room.PricePerNight));
                return sum;
            }
        }

        public IRepository<IRoom> Rooms => (IRepository<IRoom>)rooms;

        public IRepository<IBooking> Bookings => (IRepository<IBooking>)bookings;
    }
}
