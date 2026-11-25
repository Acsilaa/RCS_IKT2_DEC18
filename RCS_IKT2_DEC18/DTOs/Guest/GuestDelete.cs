using RCS_IKT2_DEC18.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RCS_IKT2_DEC18.DTOs.Guest
{
    public class GuestDelete
    {

        public int Id { get; set; }
        [Display(Name="Név")]
        public required string Name { get; set; }
        [Display(Name = "Email")]
        public required string Email { get; set; }

        [Display(Name = "Foglalások száma")]
        public required int BookingCount { get; set; }
    }
}
