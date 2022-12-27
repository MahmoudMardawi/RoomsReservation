using RoomsReservation.Db.Dtos;

namespace RoomsReservation.Services.IServices
{
    public interface IRoomService
    {
        void Add(RoomDto room);
        void Delete(int id);
        RoomDto Get(int id);
        IEnumerable<RoomDto> GetAll();
        void Update(RoomDto room);
        IEnumerable<ManagerDto> GetManagersForRoom(int id);
        void AddManagerToRoom(int roomId, int managerId);
        void RemoveManagerFromRoom(int roomId, int managerId);

    }
}
