using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCS_IKT2_DEC18.Models;
using RCS_IKT2_DEC18.Data;
using RCS_IKT2_DEC18.DTOs.Guest;

namespace RCS_IKT2_DEC18.Pages.GuestPages;

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
    public GuestCreate Guest { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Guests.Add(new Models.Guest
        {
            Name = Guest.Name,
            Email = Guest.Email,
            Phone = Guest.Phone,
            RegisteredAt = DateTime.Now,
        });
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
