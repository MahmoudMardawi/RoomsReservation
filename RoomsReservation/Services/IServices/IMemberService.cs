using RoomsReservation.Db.Dtos;

namespace RoomsReservation.Services.IServices
{
    public interface IMemberService
    {
        void Add(MemberDto member);
        void Delete(string username);
        MemberDto Get(string username);
        IEnumerable<MemberDto> GetAll();
        void Update(MemberDto member);
    }

}
