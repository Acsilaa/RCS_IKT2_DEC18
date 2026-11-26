using System.ComponentModel.DataAnnotations;

namespace RCS_IKT2_DEC18.DTOs.Room
{
    public class RoomDisplay
    {
        public int Id { get; set; }
        [Display(Name="Szám")]
        public required int Number { get; set; }
        [Display(Name="Emelet")]
        public required int Floor { get; set; }
        [Display(Name="Szobatípus")]
        public required string RoomType { get; set; }
        [Display(Name="Elérhető")]
        public required bool IsActive { get; set; }
    }
}
