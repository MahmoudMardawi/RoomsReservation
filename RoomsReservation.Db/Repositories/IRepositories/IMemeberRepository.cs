
using RoomsReservation.Db.Models;

namespace RoomsReservation.Db.Repositories.IRepositories
{
    public interface IMembersRepository
    {
        Member GetById(int id);
        Member GetByUsername(string username);
        IEnumerable<Member> GetAll();
        void Add(Member member);
        void Update(Member member);
        void Delete(int id);
    }

}
