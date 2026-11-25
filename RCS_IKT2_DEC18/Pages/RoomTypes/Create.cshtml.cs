using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCS_IKT2_DEC18.Models;
using RCS_IKT2_DEC18.Data;
using RCS_IKT2_DEC18.DTOs;

namespace RCS_IKT2_DEC18.Pages.RoomTypePages;

public class CreateModel : PageModel
{
    private readonly HotelDbContext _context;

    public CreateModel(HotelDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public RoomTypeCreate RoomType { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.RoomTypes.Add(new Models.RoomType {
            Name = RoomType.Name,
            Capacity = RoomType.Capacity,
            PricePerNight = RoomType.PricePerNight,
            Description = RoomType.Description
        });
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
