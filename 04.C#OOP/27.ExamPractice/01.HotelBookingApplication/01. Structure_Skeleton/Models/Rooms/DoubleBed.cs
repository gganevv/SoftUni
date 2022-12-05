namespace BookingApp.Models.Rooms
{
    public class DoubleBed : Room
    {
        private const int DEFAULT_BED_CAPACITY = 2;
        public DoubleBed() : base(DEFAULT_BED_CAPACITY)
        {
        }
    }
}