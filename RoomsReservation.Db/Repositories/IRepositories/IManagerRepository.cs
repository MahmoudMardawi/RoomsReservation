using RoomsReservation.Db.Models;

namespace RoomsReservation.Db.Repositories.IRepositories
{
    public interface IManagersRepository
    {

        Manager GetById(int id);
        Manager GetByUsername(string username);
        IEnumerable<Manager> GetAll();
        void Add(Manager manager);
        void Update(Manager manager);
        void Delete(int id);
        void AddRoomToManager(int managerId, int roomId);
        void RemoveRoomFromManager(int managerId, int roomId);
        IEnumerable<Room> GetRoomsForManager(int managerId);
        void SaveChanges();

    }

}
