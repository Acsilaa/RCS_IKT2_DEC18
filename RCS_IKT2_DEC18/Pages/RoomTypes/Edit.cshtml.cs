using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCS_IKT2_DEC18.Models;
using RCS_IKT2_DEC18.Data;
using RCS_IKT2_DEC18.DTOs.RoomType;

namespace RCS_IKT2_DEC18.Pages.RoomTypePages;

public class EditModel : PageModel
{
    private readonly HotelDbContext _context;

    public EditModel(HotelDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public RoomTypeEdit RoomType { get; set; } = default!;

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
        RoomType = new RoomTypeEdit
        {
            Id = roomtype.Id,
            Name = roomtype.Name,
            Capacity = roomtype.Capacity,
            PricePerNight = roomtype.PricePerNight,
            Description = roomtype.Description
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

        try
        {
            await _context.RoomTypes.Where(rt => rt.Id == RoomType.Id).ExecuteUpdateAsync(rt => rt
                .SetProperty(r => r.Name, RoomType.Name)
                .SetProperty(r => r.Capacity, RoomType.Capacity)
                .SetProperty(r => r.PricePerNight, RoomType.PricePerNight)
                .SetProperty(r => r.Description, RoomType.Description));
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RoomTypeExists(RoomType.Id))
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

    private bool RoomTypeExists(int id)
    {
        return _context.RoomTypes.Any(e => e.Id == id);
    }
}
