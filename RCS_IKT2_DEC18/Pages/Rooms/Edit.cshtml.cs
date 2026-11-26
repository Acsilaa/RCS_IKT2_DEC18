using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCS_IKT2_DEC18.Models;
using RCS_IKT2_DEC18.Data;
using RCS_IKT2_DEC18.DTOs.Room;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RCS_IKT2_DEC18.Pages.RoomPages;

public class EditModel : PageModel
{
    private readonly HotelDbContext _context;

    public EditModel(HotelDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public RoomEdit Room { get; set; } = default!;
    public SelectList RoomTypes { get; set; } = default!;

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
        RoomTypes = new SelectList(_context.RoomTypes, "Id", "Name", room.RoomTypeId);
        Room = new RoomEdit
        {
            Id = room.Id,
            Number = room.Number,
            Floor = room.Floor,
            RoomTypeId = room.RoomTypeId,
            IsActive = room.IsActive
        };
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

        _context.Rooms.Update(new Models.Room { Floor = Room.Floor, IsActive = Room.IsActive, Number = Room.Number, RoomTypeId = Room.RoomTypeId, Id = Room.Id });

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RoomExists(Room.Id))
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

    private bool RoomExists(int id)
    {
        return _context.Rooms.Any(e => e.Id == id);
    }
}
