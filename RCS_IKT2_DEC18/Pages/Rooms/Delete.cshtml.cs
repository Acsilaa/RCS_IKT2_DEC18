using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCS_IKT2_DEC18.Models;
using RCS_IKT2_DEC18.Data;
using RCS_IKT2_DEC18.DTOs.Room;

namespace RCS_IKT2_DEC18.Pages.RoomPages;

public class DeleteModel : PageModel
{
    private readonly HotelDbContext _context;

    public DeleteModel(HotelDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public RoomDelete Room { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var room = await _context.Rooms.Include(r => r.RoomType).Include(r => r.Bookings).FirstOrDefaultAsync(m => m.Id == id);
        if (room is null)
        {
            return NotFound();
        }
        else
        {
            Room = new RoomDelete { Floor=room.Floor, IsActive = room.IsActive, Number = room.Number, RoomType = room.RoomType.Name, Id = room.Id, Bookings = room.Bookings };
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var room = (await  _context.Rooms.Include(r => r.RoomType).Include(r => r.Bookings).Where(r => r.Id == id).ToListAsync())[0] ?? null;
        if (room != null && room.Bookings.Count == 0)
        {
            _context.Rooms.Where(r => r.Id == id).ExecuteDelete();
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
