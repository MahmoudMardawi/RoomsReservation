using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomsReservation.Db.Models
{
    public class Member
    {
        public Member(string username)
        {
            Username = username;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        [Required]

        public string Email { get; set; }
       

    }
}
