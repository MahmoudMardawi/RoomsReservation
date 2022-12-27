namespace RoomsReservation.Db.Dtos
{
    public class ReservationDto
    {
        public ReservationDto()
        {
            Members = new List<MemberDto>();
            Managers= new List<ManagerDto>();
            Rooms= new List<RoomDto>();
        }
        public int Duration { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public List<MemberDto> Members { get; set; }
        public List<ManagerDto> Managers { get; set; }
        public List<RoomDto> Rooms { get; set; }

    }
}
