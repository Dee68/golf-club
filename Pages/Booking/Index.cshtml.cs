using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GolfClub.Data;
using GolfClub.Models;
using GolfClub.Utilities;

namespace GolfClub.Pages.Booking
{
    public class IndexModel : PageModel
    {
        private readonly GolfClub.Data.GolfDbContext _context;

        public IndexModel(GolfClub.Data.GolfDbContext context)
        {
            _context = context;
        }

        public PaginatedList<GolfClub.Models.Booking> Bookings { get;set; } = default!;

        public async Task OnGetAsync(int? pageIndex)
        {
            if (_context.Bookings != null)
            {
                var query = _context.Bookings
                    .Include(b => b.Golfer)
                    .Include(b => b.Player1)
                    .Include(b => b.Player2)
                    .Include(b => b.Player3)
                    .Include(b => b.Player4)
                    .OrderByDescending(b => b.Id).AsQueryable();
                int pageSize = 3;
                Bookings = await PaginatedList<GolfClub.Models.Booking>.CreateAsync(query, pageIndex ?? 1, pageSize);
                
            }
        }
    }
}
