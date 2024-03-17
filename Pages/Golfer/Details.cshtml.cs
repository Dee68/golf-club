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
    public class DetailsModel : PageModel
    {
        private readonly GolfClub.Data.GolfDbContext _context;

        public DetailsModel(GolfClub.Data.GolfDbContext context)
        {
            _context = context;
        }

      public GolfClub.Models.Golfer Golfer { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Golfers == null)
            {
                return NotFound();
            }

            var golfer = await _context.Golfers.Include(g => g.Bookings).FirstOrDefaultAsync(m => m.Id == id);

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
    }
}
