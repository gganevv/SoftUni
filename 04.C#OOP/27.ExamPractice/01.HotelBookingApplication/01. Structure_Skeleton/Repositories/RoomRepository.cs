namespace BookingApp.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.Rooms.Contracts;

    public class RoomRepository : IRepository<IRoom>
    {
        private readonly HashSet<IRoom> rooms;

        public RoomRepository()
        {
            rooms = new HashSet<IRoom>();
        }

        public void AddNew(IRoom room)
        {
            rooms.Add(room);
        }

        public IReadOnlyCollection<IRoom> All() => rooms;

        public IRoom Select(string criteria) => rooms.FirstOrDefault(x => x.GetType().Name == criteria);
    }
}