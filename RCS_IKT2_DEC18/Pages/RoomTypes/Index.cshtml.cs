using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCS_IKT2_DEC18.Models;
using RCS_IKT2_DEC18.Data;
using RCS_IKT2_DEC18.DTOs;

namespace RCS_IKT2_DEC18.Pages.RoomTypePages;

public class IndexModel : PageModel
{
    private readonly HotelDbContext _context;

    public IndexModel(HotelDbContext context)
    {
        _context = context;
    }

    public IList<RoomTypeDisplay> RoomType { get; set; } = default!;

    public async Task OnGetAsync()
    {
        RoomType = await _context.RoomTypes.Include(r => r.Rooms).Select(rt => new RoomTypeDisplay
        {
            Id = rt.Id,
            Name = rt.Name,
            Capacity = rt.Capacity,
            PricePerNight = rt.PricePerNight,
            Description = rt.Description,
            RoomCount = rt.Rooms.Count
        }).ToListAsync();
    }
}
