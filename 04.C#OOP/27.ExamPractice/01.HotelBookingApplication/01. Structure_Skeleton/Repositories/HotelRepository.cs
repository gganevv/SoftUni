namespace BookingApp.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
  
    using BookingApp.Models.Hotels;
    using BookingApp.Repositories.Contracts;

    public class HotelRepository : IRepository<Hotel>
    {
        private HashSet<Hotel> hotels;

        public HotelRepository()
        {
            hotels = new HashSet<Hotel>();
        }
        public void AddNew(Hotel hotel)
        {
            hotels.Add(hotel);
        }

        public IReadOnlyCollection<Hotel> All() => hotels;

        public Hotel Select(string criteria) => hotels.FirstOrDefault(x => x.FullName == criteria);
    }
}