namespace BookingApp.Repositories
{
    using System.Collections.Generic;
  
    using Repositories.Contracts;
    using Models.Hotels.Contacts;
    using System.Linq;

    public class HotelRepository : IRepository<IHotel>
    {
        private HashSet<IHotel> hotels;

        public HotelRepository()
        {
            hotels = new HashSet<IHotel>();
        }
        public void AddNew(IHotel hotel)
        {
            hotels.Add(hotel);
        }

        public IReadOnlyCollection<IHotel> All() => hotels;

        public IHotel Select(string criteria) => hotels.FirstOrDefault(x => x.FullName == criteria);
    }
}