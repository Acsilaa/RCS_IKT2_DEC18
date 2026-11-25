using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RCS_IKT2_DEC18.Models
{
    [Index(nameof(BookingId), IsUnique = true)]
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required int BookingId { get; set; }
        [Range(0.0f, 5.0f)]
        public required float Rating { get; set; }
        public string? Comment { get; set; }
        public required DateTime CreatedAt { get; set; }

        // Navigation property
        public required Booking Booking { get; set; }
    }
}
