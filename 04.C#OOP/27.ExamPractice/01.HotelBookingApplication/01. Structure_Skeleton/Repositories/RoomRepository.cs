namespace BookingApp.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using BookingApp.Models.Rooms;

    public class RoomRepository : IRepository<Room>
    {
        private readonly HashSet<Room> rooms;

        public RoomRepository()
        {
            rooms = new HashSet<Room>();
        }

        public void AddNew(Room room)
        {
            rooms.Add(room);
        }

        public IReadOnlyCollection<Room> All() => rooms;

        public Room Select(string criteria) => rooms.FirstOrDefault(x => x.GetType().Name == criteria);
    }
}