using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RCS_IKT2_DEC18.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class RoomType
    {
        [Key]
        public required int Id { get; set; }
        [MaxLength(50)]
        public required string Name { get; set; }
        [Range(1, 50)]
        public required int Capacity { get; set; }
        [Range(0.000000001d, Double.MaxValue)]
        public required decimal PricePerNight { get; set; }
        public string? Description { get; set; }


        // Navigation property
        public required List<Room> Rooms { get; set; }
    }
}
