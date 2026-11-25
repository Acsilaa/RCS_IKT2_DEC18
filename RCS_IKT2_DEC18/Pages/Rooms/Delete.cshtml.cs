using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCS_IKT2_DEC18.Models;
using RCS_IKT2_DEC18.Data;

namespace RCS_IKT2_DEC18.Pages.RoomPages;

public class DeleteModel : PageModel
{
    private readonly HotelDbContext _context;

    public DeleteModel(HotelDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Room Room { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var room = await _context.Rooms.FirstOrDefaultAsync(m => m.Id == id);
        if (room is null)
        {
            return NotFound();
        }
        else
        {
            Room = room;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var room = await _context.Rooms.FindAsync(id);
        if (room != null)
        {
            Room = room;
            _context.Rooms.Remove(Room);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
