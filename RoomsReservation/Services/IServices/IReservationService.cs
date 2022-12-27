using RoomsReservation.Db.Dtos;

namespace RoomsReservation.Services.IServices
{
    public interface IReservationService
    {
        void Add(ReservationDto reservation);
        void Delete(int id);
        ReservationDto Get(int id);
        IEnumerable<ReservationDto> GetAll();
        void Update(ReservationDto reservation);
        IEnumerable<ReservationDto> GetByMemberId(int memberId);
        IEnumerable<ReservationDto> GetByRoomId(int roomId);

    }
}
