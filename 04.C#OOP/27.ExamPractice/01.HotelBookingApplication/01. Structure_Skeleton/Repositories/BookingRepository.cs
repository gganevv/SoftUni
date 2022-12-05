namespace BookingApp.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    
    using Repositories.Contracts;
    using Models.Bookings.Contracts;

    public class BookingRepository : IRepository<IBooking>
    {
        private HashSet<IBooking> bookings;

        public BookingRepository()
        {
            bookings = new HashSet<IBooking>();
        }
        public void AddNew(IBooking booking)
        {
            bookings.Add(booking);
        }

        public IReadOnlyCollection<IBooking> All() => bookings;

        public IBooking Select(string criteria) => bookings.FirstOrDefault(x => x.BookingNumber == int.Parse(criteria));
    }
}
