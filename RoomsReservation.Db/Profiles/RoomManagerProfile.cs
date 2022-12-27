using AutoMapper;
using RoomsReservation.Db.Dtos;
using RoomsReservation.Db.Models;

namespace RoomsReservation.Db.Profiles
{
    public class RoomManagerProfile : Profile
    {
        public RoomManagerProfile()
        {
            this.CreateMap<RoomManager, RoomManagerDto>(MemberList.Source)
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
        }
    }
}
