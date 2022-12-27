using System.ComponentModel.DataAnnotations;

namespace RoomsReservation.Db.Dtos
{
    public class MemberDto
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
