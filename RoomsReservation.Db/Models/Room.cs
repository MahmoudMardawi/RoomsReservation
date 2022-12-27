using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomsReservation.Db.Models

{
    public class Room
    {
        public Room()
        {
            RoomManagers = new List<RoomManager>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool Available { get; set; }
        public int Size { get; set; }
        public List<RoomManager> RoomManagers { get; private set; }
        
    }
}
