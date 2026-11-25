using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RCS_IKT2_DEC18.Models;
using RCS_IKT2_DEC18.Data;

namespace RCS_IKT2_DEC18.Pages.ReviewPages;

public class IndexModel : PageModel
{
    private readonly HotelDbContext _context;

    public IndexModel(HotelDbContext context)
    {
        _context = context;
    }

    public IList<Review> Review { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Review = await _context.Reviews.ToListAsync();
    }
}
