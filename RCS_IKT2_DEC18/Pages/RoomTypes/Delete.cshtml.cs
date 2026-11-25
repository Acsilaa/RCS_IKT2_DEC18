using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCS_IKT2_DEC18.Models;
using RCS_IKT2_DEC18.Data;

namespace RCS_IKT2_DEC18.Pages.RoomTypePages;

public class DeleteModel : PageModel
{
    private readonly HotelDbContext _context;

    public DeleteModel(HotelDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public RoomType RoomType { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var roomtype = await _context.RoomTypes.FirstOrDefaultAsync(m => m.Id == id);
        if (roomtype is null)
        {
            return NotFound();
        }
        else
        {
            RoomType = roomtype;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var roomtype = await _context.RoomTypes.FindAsync(id);
        if (roomtype != null)
        {
            RoomType = roomtype;
            _context.RoomTypes.Remove(RoomType);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
