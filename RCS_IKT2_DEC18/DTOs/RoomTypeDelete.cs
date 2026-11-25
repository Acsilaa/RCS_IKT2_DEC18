using RCS_IKT2_DEC18.Models;
using System.ComponentModel.DataAnnotations;

namespace RCS_IKT2_DEC18.DTOs
{
    public class RoomTypeDelete
    {

        public required int Id { get; set; }
        [Display(Name="Név")]
        public required string Name { get; set; }
        [Display(Name="Ilyen szobák")]
        public int RoomCount { get; set; }
    }
}
