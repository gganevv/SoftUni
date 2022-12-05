namespace BookingApp.Models.Rooms
{
    using System;

    using Rooms.Contracts;
    using Utilities.Messages;

    public abstract class Room : IRoom
    {
        private double pricePerNight;
        public Room(int bedCapacity)
        {
            BedCapacity = bedCapacity;
            PricePerNight = 0;
        }

        public int BedCapacity { get; private set; }
        public double PricePerNight 
        {
            get => pricePerNight;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                }
                pricePerNight = value;
            }
        }

        public void SetPrice(double price)
        {
            PricePerNight = price;
        }
    }
}