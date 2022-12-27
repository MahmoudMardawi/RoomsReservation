using AutoMapper;
using RoomsReservation.Db.Dtos;
using RoomsReservation.Db.Models;

namespace RoomsReservation.Db.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            this.CreateMap<Room, RoomDto>(MemberList.Source)
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
        }
    }
}
