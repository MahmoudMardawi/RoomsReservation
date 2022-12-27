using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomsReservation.Db.Models
{
    public class Reservation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public int Duration { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }

        [ForeignKey("ManagerId")]
        public virtual Manager? Manager { get; set; }
        public int? ManagerId { get; set; }
        

        [ForeignKey("RoomId")]
        public virtual Room? Room { get; set; }
        public int? RoomId { get; set; }

        [ForeignKey("MemberId")]
        public virtual Member? Member { get; set; }
        public int? MemberId { get; set; }
        public bool Approval { get; set; }
    }
}
