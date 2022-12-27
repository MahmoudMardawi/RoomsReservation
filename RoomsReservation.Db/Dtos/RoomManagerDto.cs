namespace RoomsReservation.Db.Dtos
{
    public class RoomManagerDto
    {
        public RoomManagerDto()
        {
            Rooms = new List<RoomDto>();
            Managers = new List<ManagerDto>();
        }
        public List<RoomDto> Rooms { get; set; }
        public List<ManagerDto> Managers { get; set; }
    }
}
