using System.ComponentModel.DataAnnotations;

namespace RCS_IKT2_DEC18.DTOs.Room
{
    public class RoomEdit
    {
        public int Id { get; set; }
        [Display(Name="Szám")]
        public required int Number { get; set; }
        [Display(Name="Emelet")]
        public required int Floor { get; set; }
        [Display(Name="Szobatípus")]
        public required int RoomTypeId { get; set; }
        [Display(Name="Elérhető")]
        public required bool IsActive { get; set; }
    }
}
