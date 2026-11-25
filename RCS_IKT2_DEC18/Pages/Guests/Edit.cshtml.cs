using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCS_IKT2_DEC18.Models;
using RCS_IKT2_DEC18.Data;

namespace RCS_IKT2_DEC18.Pages.GuestPages;

public class EditModel : PageModel
{
    private readonly HotelDbContext _context;

    public EditModel(HotelDbContext context)
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
        Guest = guest;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Guest).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!GuestExists(Guest.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool GuestExists(int id)
    {
        return _context.Guests.Any(e => e.Id == id);
    }
}
