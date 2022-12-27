using RoomsReservation.Db.Contexts;
using RoomsReservation.Db.Models;
using RoomsReservation.Db.Repositories.IRepositories;

namespace RoomsReservation.Db.Repositories
{
    public class RoomsRepository : IRoomsRepository
    {
        private readonly RoomsReservationDbContext _context;

        public RoomsRepository(RoomsReservationDbContext context)
        {
            _context = context;
        }

        public void Add(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var room = _context.Rooms.Find(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }
        }

        public Room GetById(int id)
        {
            return _context.Rooms.Find(id);
        }

        public IEnumerable<Room> GetAll()
        {
            return _context.Rooms;
        }

        public void Update(Room room)
        {
            _context.Rooms.Update(room);
            _context.SaveChanges();
        }

        public IEnumerable<Room> GetRoomsForManager(int managerId)
        {
            return _context.RoomManagers
                .Where(rm => rm.ManagerId == managerId)
                .Select(rm => rm.Room);
        }

        public void AddRoomToManager(Room room, Manager manager)
        {
            _context.RoomManagers.Add(new RoomManager { Room = room, Manager = manager });
            _context.SaveChanges();
        }

        public void RemoveRoomFromManager(Room room, Manager manager)
        {
            var roomManager = _context.RoomManagers
                .Where(rm => rm.Room == room && rm.Manager == manager)
                .SingleOrDefault();

            if (roomManager != null)
            {
                _context.RoomManagers.Remove(roomManager);
                _context.SaveChanges();
            }

        }
    }
}