using AutoMapper;
using RoomsReservation.Db.Dtos;
using RoomsReservation.Db.Models;

namespace RoomsReservation.Db.Profiles
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            this.CreateMap<Member, MemberDto>(MemberList.Source)
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
        }
    }
}
