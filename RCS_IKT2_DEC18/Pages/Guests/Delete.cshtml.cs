using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCS_IKT2_DEC18.Models;
using RCS_IKT2_DEC18.Data;
using RCS_IKT2_DEC18.DTOs.Guest;

namespace RCS_IKT2_DEC18.Pages.GuestPages;

public class DeleteModel : PageModel
{
    private readonly HotelDbContext _context;

    public DeleteModel(HotelDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public GuestDelete Guest { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var guest = await _context.Guests.Include(g => g.Bookings).FirstOrDefaultAsync(m => m.Id == id);
        if (guest is null)
        {
            return NotFound();
        }
        else
        {
            Guest = new GuestDelete
            {
                Id = guest.Id,
                BookingCount = guest.Bookings.Count,
                Email = guest.Email, 
                Name = guest.Name
            };
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var guest = await _context.Guests.FindAsync(id);
        if (guest != null)
        {
            Guest = new GuestDelete
            {
                Id = guest.Id,
                BookingCount = guest.Bookings.Count,
                Email = guest.Email,
                Name = guest.Name
            };
            _context.Guests.Where(g => g.Id == id).ExecuteDelete();
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
