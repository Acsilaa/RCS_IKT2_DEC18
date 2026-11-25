using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCS_IKT2_DEC18.Models;
using RCS_IKT2_DEC18.Data;

namespace RCS_IKT2_DEC18.Pages.BookingPages;

public class DetailsModel : PageModel
{
    private readonly HotelDbContext _context;
    public DetailsModel(HotelDbContext context)
    {
        _context = context;
    }

    public Booking Booking { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var booking = await _context.Bookings.FirstOrDefaultAsync(m => m.Id == id);
        if (booking is null)
        {
            return NotFound();
        }
        else
        {
            Booking = booking;
        }

        return Page();
    }
}
