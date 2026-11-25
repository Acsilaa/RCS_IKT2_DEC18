using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RCS_IKT2_DEC18.Models
{
    public enum BookingStatus
    {
        Függő,
        Megerősített,
        Bejelentkezett,
        Kijelentkezett,
        Lemondott
    }
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? GuestId { get; set; }
        public required int RoomId { get; set; }
        public required DateTime CheckIn { get; set; }
        public required DateTime CheckOut { get; set; }
        [Range(1, int.MaxValue)]
        public required int NumberOfGuests { get; set; }
        public required BookingStatus Status { get; set; }
        [Range(0, Double.MaxValue)]
        public required decimal TotalPrice { get; set; }
        public required DateTime CreatedAt { get; set; }


        // Navigation properties
        public Guest? Guest { get; set; }
        public required Room Room { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
