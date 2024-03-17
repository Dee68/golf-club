using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GolfClub.Data;
using GolfClub.Models;

namespace GolfClub.Pages.Golfer
{
    public class DeleteModel : PageModel
    {
        private readonly GolfClub.Data.GolfDbContext _context;

        public DeleteModel(GolfClub.Data.GolfDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public GolfClub.Models.Golfer Golfer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Golfers == null)
            {
                return NotFound();
            }

            var golfer = await _context.Golfers.FirstOrDefaultAsync(m => m.Id == id);

            if (golfer == null)
            {
                return NotFound();
            }
            else 
            {
                Golfer = golfer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Golfers == null)
            {
                return NotFound();
            }
            var golfer = await _context.Golfers.FindAsync(id);

            if (golfer != null)
            {
                Golfer = golfer;
                _context.Golfers.Remove(Golfer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
