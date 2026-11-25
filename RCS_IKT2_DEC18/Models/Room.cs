using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RCS_IKT2_DEC18.Models
{
    [Index(nameof(Number), IsUnique = true)]
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int Id { get; set; }
        public required int Number { get; set; }
        public required int Floor { get; set; }
        public required int RoomTypeId { get; set; }
        public required bool IsActive { get; set; }


        // Navigation property
        public required RoomType RoomType { get; set; }
        public required List<Booking> Bookings { get; set; }
    }
}
