namespace BookingApp.Models.Rooms
{
    public class Studio : Room
    {
        private const int DEFAULT_BED_CAPACITY = 4;
        public Studio() : base(DEFAULT_BED_CAPACITY)
        {
        }
    }
}