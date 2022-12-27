using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomsReservation.Db.Models
{
    public class RoomManager
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public Room? Room { get; set; }
        public int RoomId { get; set; }
        public Manager? Manager { get; set; }
        public int ManagerId { get; set; }


    }
}
