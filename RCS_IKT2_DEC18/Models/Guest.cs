using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RCS_IKT2_DEC18.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Guest
    {
        [Key]
        public required int Id { get; set; }
        [MaxLength(100)]
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public required DateTime RegisteredAt { get; set; }


        // Navigation property
        public required List<Booking> Bookings { get; set; }
    }
}
