using AutoMapper;
using RoomsReservation.Db.Dtos;
using RoomsReservation.Db.Models;

namespace RoomsReservation.Db.Profiles
{
    public class ManagerProfile : Profile
    {
        public ManagerProfile()
        {
            this.CreateMap<Manager, ManagerDto>(MemberList.Source)
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
        }
    }
}
