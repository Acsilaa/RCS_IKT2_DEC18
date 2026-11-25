using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCS_IKT2_DEC18.Models;
using RCS_IKT2_DEC18.Data;

namespace RCS_IKT2_DEC18.Pages.ReviewPages;

public class DeleteModel : PageModel
{
    private readonly HotelDbContext _context;

    public DeleteModel(HotelDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Review Review { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var review = await _context.Reviews.FirstOrDefaultAsync(m => m.Id == id);
        if (review is null)
        {
            return NotFound();
        }
        else
        {
            Review = review;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var review = await _context.Reviews.FindAsync(id);
        if (review != null)
        {
            Review = review;
            _context.Reviews.Remove(Review);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
