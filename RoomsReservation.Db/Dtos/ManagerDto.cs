using System.ComponentModel.DataAnnotations;

namespace RoomsReservation.Db.Dtos
{
    public class ManagerDto
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
    }
}
