using AutoMapper;
using RoomsReservation.Db.Dtos;
using RoomsReservation.Db.Models;
using RoomsReservation.Db.Repositories.IRepositories;
using RoomsReservation.Services.IServices;

namespace RoomsReservation.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMembersRepository _repository;
        private readonly IMapper _mapper;

        public MemberService(IMembersRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Add(MemberDto memberDto)
        {
            var member = _mapper.Map<Member>(memberDto);
            _repository.Add(member);
        }

        public void Delete(string username)
        {
            var member = _repository.GetByUsername(username);
            _repository.Delete(member.Id);
        }

        public MemberDto Get(string username)
        {
            var member = _repository.GetByUsername(username);
            return _mapper.Map<MemberDto>(member);
        }

        public IEnumerable<MemberDto> GetAll()
        {
            var members = _repository.GetAll();
            return _mapper.Map<IEnumerable<MemberDto>>(members);
        }

        public void Update(MemberDto memberDto)
        {
            var member = _mapper.Map<Member>(memberDto);
            _repository.Update(member);
        }
    }
}
