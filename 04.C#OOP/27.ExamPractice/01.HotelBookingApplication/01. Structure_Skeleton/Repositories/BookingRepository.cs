namespace BookingApp.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    
    using Repositories.Contracts;
    using BookingApp.Models.Bookings;

    public class BookingRepository : IRepository<Booking>
    {
        private HashSet<Booking> bookings;

        public BookingRepository()
        {
            bookings = new HashSet<Booking>();
        }
        public void AddNew(Booking booking)
        {
            bookings.Add(booking);
        }

        public IReadOnlyCollection<Booking> All() => bookings;

        public Booking Select(string criteria) => bookings.FirstOrDefault(x => x.BookingNumber == int.Parse(criteria));
    }
}
