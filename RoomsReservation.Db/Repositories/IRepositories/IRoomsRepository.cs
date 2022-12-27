using RoomsReservation.Db.Models;

namespace RoomsReservation.Db.Repositories.IRepositories
{
    public interface IRoomsRepository
    {
        void Add(Room room);
        void Delete(int id);
        Room GetById(int id);
        IEnumerable<Room> GetAll();
        void Update(Room room);
        IEnumerable<Room> GetRoomsForManager(int managerId);
        void AddRoomToManager(Room room, Manager manager);
        void RemoveRoomFromManager(Room room, Manager manager);
    }

}
