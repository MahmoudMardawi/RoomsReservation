using RoomsReservation.Db.Models;

namespace RoomsReservation.Db.Repositories.IRepositories
{
    public interface IReservationsRepository
    {
        Reservation GetById(int id);
        IEnumerable<Reservation> GetByManagerId(int managerId);
        IEnumerable<Reservation> GetByMemberId(int memberId);
        IEnumerable<Reservation> GetByRoomId(int roomId);
        IEnumerable<Reservation> GetAll();
        void Add(Reservation reservation);
        void Update(Reservation reservation);
        void Delete(int id);
    }

}
