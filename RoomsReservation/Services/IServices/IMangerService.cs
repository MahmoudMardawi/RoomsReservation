using System.Collections.Generic;
using RoomsReservation.Db.Dtos;
using RoomsReservation.Db.Models;

namespace RoomsReservation.Services
{
    public interface IManagerService
    {
        ManagerDto GetById(int id);
        ManagerDto GetByUsername(string username);
        IEnumerable<ManagerDto> GetAll();
        void Add(ManagerDto manager);
        void Update(ManagerDto manager);
        void Delete(int id);
        void AddRoomToManager(int managerId, int roomId);
        void RemoveRoomFromManager(int managerId, int roomId);
        IEnumerable<RoomDto> GetRoomsForManager(int managerId);
    }
}
