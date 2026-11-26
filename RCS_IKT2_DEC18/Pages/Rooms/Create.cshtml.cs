using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCS_IKT2_DEC18.Models;
using RCS_IKT2_DEC18.Data;
using RCS_IKT2_DEC18.DTOs.Room;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RCS_IKT2_DEC18.Pages.RoomPages;

public class CreateModel : PageModel
{
    private readonly HotelDbContext _context;

    public CreateModel(HotelDbContext context)
    {
        _context = context;
    }
    public SelectList RoomTypes { get; set; } = default!;
    public IActionResult OnGet()
    {
        RoomTypes = new SelectList(_context.RoomTypes, "Id", "Name");
        return Page();
    }

    [BindProperty]
    public RoomCreate Room { get; set; } = default!;
    

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Rooms.Add(
            new Room { 
                Floor = Room.Floor,
                Number = Room.Number,
                IsActive = Room.IsActive,
                RoomTypeId = Room.RoomTypeId,
            }
            );
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
