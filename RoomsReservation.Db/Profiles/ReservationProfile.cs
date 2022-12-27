using AutoMapper;
using RoomsReservation.Db.Dtos;
using RoomsReservation.Db.Models;

namespace RoomsReservation.Db.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            this.CreateMap<Reservation, ReservationDto>(MemberList.Source)
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
        }
    }
}
