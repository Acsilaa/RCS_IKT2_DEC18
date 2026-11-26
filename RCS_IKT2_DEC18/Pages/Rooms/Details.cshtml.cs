using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCS_IKT2_DEC18.Models;
using RCS_IKT2_DEC18.Data;
using RCS_IKT2_DEC18.DTOs.Room;

namespace RCS_IKT2_DEC18.Pages.RoomPages;

public class DetailsModel : PageModel
{
    private readonly HotelDbContext _context;
    public DetailsModel(HotelDbContext context)
    {
        _context = context;
    }

    public RoomDisplay Room { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var room = await _context.Rooms.Include(r=>r.RoomType).FirstOrDefaultAsync(m => m.Id == id);
        if (room is null)
        {
            return NotFound();
        }
        else
        {
            Room = new RoomDisplay { 
                Floor = room.Floor,
                Id = room.Id,
                Number = room.Number,
                RoomType = room.RoomType.Name,
                IsActive = room.IsActive
            };
        }

        return Page();
    }
}
