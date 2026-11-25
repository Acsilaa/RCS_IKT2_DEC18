using RCS_IKT2_DEC18.Models;
using System.ComponentModel.DataAnnotations;

namespace RCS_IKT2_DEC18.DTOs
{
    public class RoomTypeEdit
    {
        public int Id { get; set; }
        [Display(Name="Név")]
        public required string Name { get; set; }
        [Display(Name="Férőhelyek")]
        public required int Capacity { get; set; }
        [Display(Name="Ár/éj (Ft)")]
        public required decimal PricePerNight { get; set; }
        [Display(Name="Leírás")]
        public string? Description { get; set; }
    }
}
