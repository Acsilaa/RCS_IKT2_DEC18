using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCS_IKT2_DEC18.Models;
using RCS_IKT2_DEC18.Data;
using RCS_IKT2_DEC18.DTOs.RoomType;

namespace RCS_IKT2_DEC18.Pages.RoomTypePages;

public class DeleteModel : PageModel
{
    private readonly HotelDbContext _context;

    public DeleteModel(HotelDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public RoomTypeDelete RoomType { get; set; } = default!;

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
            RoomType = new RoomTypeDelete
            {
                Id = roomtype.Id,
                Name = roomtype.Name,
                RoomCount = roomtype.Rooms.Count
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

        var roomtype = await _context.RoomTypes.FindAsync(id);
        if (roomtype != null)
        {
            RoomType = new RoomTypeDelete
            {
                Id = roomtype.Id,
                Name = roomtype.Name,
                RoomCount = roomtype.Rooms.Count
            };
            _context.RoomTypes.Where(rt => rt.Id == id).ExecuteDelete();
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
