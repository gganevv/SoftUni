namespace BookingApp.Models.Rooms
{
    public class Apartment : Room
    {
        private const int DEFAULT_BED_CAPACITY = 6;
        public Apartment() : base(DEFAULT_BED_CAPACITY)
        {
        }
    }
}