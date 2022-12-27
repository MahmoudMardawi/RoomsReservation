using RoomsReservation.Db.Models;

namespace RoomsReservation.Db.Repositories.IRepositories
{
    public interface IRoomManagerRepository
    {
        RoomManager GetById(int id);
        IEnumerable<RoomManager> GetAll();
        void Add(RoomManager roomManager);
        void Update(RoomManager roomManager);
        void Delete(int id);
    }
}
