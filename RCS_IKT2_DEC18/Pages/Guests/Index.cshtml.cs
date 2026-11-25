using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCS_IKT2_DEC18.Models;
using RCS_IKT2_DEC18.Data;
using RCS_IKT2_DEC18.DTOs.Guest;

namespace RCS_IKT2_DEC18.Pages.GuestPages;

public class IndexModel : PageModel
{
    private readonly HotelDbContext _context;

    public IndexModel(HotelDbContext context)
    {
        _context = context;
    }

    public IList<GuestDisplay> Guest { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Guest = await _context.Guests.Select(g => new GuestDisplay
        {
            Id = g.Id,
            Name = g.Name,
            Email = g.Email,
            Phone = g.Phone,
            RegisteredAt = g.RegisteredAt,
            BookingCount = g.Bookings.Count
        }).ToListAsync();
    }
}
