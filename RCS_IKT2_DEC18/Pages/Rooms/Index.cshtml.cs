using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCS_IKT2_DEC18.Models;
using RCS_IKT2_DEC18.Data;
using RCS_IKT2_DEC18.DTOs.Room;

namespace RCS_IKT2_DEC18.Pages.RoomPages;

public class IndexModel : PageModel
{
    private readonly HotelDbContext _context;

    public IndexModel(HotelDbContext context)
    {
        _context = context;
    }

    public IList<RoomDisplay> Room { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Room = await _context.Rooms.Include(r => r.RoomType).Select(r => new RoomDisplay
        {
            Id = r.Id,
            Number = r.Number,
            Floor = r.Floor,
            RoomType = r.RoomType.Name,
            IsActive = r.IsActive
        }).ToListAsync();
    }
}
