using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCS_IKT2_DEC18.Models;
using RCS_IKT2_DEC18.Data;

namespace RCS_IKT2_DEC18.Pages.GuestPages;

public class DeleteModel : PageModel
{
    private readonly HotelDbContext _context;

    public DeleteModel(HotelDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Guest Guest { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var guest = await _context.Guests.FirstOrDefaultAsync(m => m.Id == id);
        if (guest is null)
        {
            return NotFound();
        }
        else
        {
            Guest = guest;
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
            Guest = guest;
            _context.Guests.Remove(Guest);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
