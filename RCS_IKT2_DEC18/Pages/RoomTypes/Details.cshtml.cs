using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCS_IKT2_DEC18.Models;
using RCS_IKT2_DEC18.Data;
using RCS_IKT2_DEC18.DTOs;

namespace RCS_IKT2_DEC18.Pages.RoomTypePages;

public class DetailsModel : PageModel
{
    private readonly HotelDbContext _context;
    public DetailsModel(HotelDbContext context)
    {
        _context = context;
    }

    public RoomTypeDisplay RoomType { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var roomtype = await _context.RoomTypes.Include(r => r.Rooms).FirstOrDefaultAsync(m => m.Id == id);
        if (roomtype is null)
        {
            return NotFound();
        }
        else
        {
            RoomType = new RoomTypeDisplay
            {
                Id = roomtype.Id,
                Name = roomtype.Name,
                Description = roomtype.Description,
                PricePerNight = roomtype.PricePerNight,
                RoomCount = roomtype.Rooms.Count,
                Capacity = roomtype.Capacity
            };
        }

        return Page();
    }
}
