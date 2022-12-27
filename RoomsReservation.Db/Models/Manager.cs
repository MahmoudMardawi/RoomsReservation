using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomsReservation.Db.Models
{
    public class Manager
    {
        public Manager()
        {
            Reservations = new List<Reservation>();
            RoomManagers = new List<RoomManager>();
        }

        public Manager(string username)
        {
            Username = username;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public  List<RoomManager> RoomManagers { get; set; }
        public virtual List<Reservation> Reservations { get; }

    }
}
