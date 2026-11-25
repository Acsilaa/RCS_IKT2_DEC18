using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCS_IKT2_DEC18.Models;
using RCS_IKT2_DEC18.Data;
using RCS_IKT2_DEC18.DTOs.Guest;

namespace RCS_IKT2_DEC18.Pages.GuestPages;

public class DetailsModel : PageModel
{
    private readonly HotelDbContext _context;
    public DetailsModel(HotelDbContext context)
    {
        _context = context;
    }

    public GuestDisplay Guest { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var guest = await _context.Guests.Include(g =>g.Bookings).FirstOrDefaultAsync(m => m.Id == id);
        if (guest is null)
        {
            return NotFound();
        }
        else
        {
            Guest = new GuestDisplay
            {
                Name = guest.Name,
                BookingCount = guest.Bookings.Count,
                Email = guest.Email,
                Phone = guest.Phone,
                RegisteredAt = guest.RegisteredAt,
                Id = guest.Id
            };
        }

        return Page();
    }
}
