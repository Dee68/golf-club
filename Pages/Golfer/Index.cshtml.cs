using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GolfClub.Data;
using GolfClub.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using GolfClub.Utilities;

namespace GolfClub.Pages.Golfer
{
    public class IndexModel : PageModel
    {
        private readonly GolfClub.Data.GolfDbContext _context;

        public IndexModel(GolfDbContext context)
        {
            _context = context;
        }

        public PaginatedList<GolfClub.Models.Golfer> Golfers { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string GenderFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? HandicapFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? HandicapMin { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? HandicapMax { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool SortDescending { get; set; }
        


        public async Task OnGetAsync(string sortBy, bool sortDescending, int? pageIndex)
        {
            SortBy = sortBy;
            SortDescending = sortDescending;
            //order golfers by descending id
            var query = _context.Golfers.OrderByDescending(g => g.Id).AsQueryable();

            // Apply filters for gender
            if (!string.IsNullOrEmpty(GenderFilter))
            {
                var genderFilter = Enum.Parse<Gender>(GenderFilter);
                query = query.Where(g => g.Gender == genderFilter);
            }
            // Apply filters for handicap
            if (HandicapFilter.HasValue)
            {
                query = query.Where(g => g.Handicap == HandicapFilter.Value);
            }
            else
            {
                if (HandicapMin.HasValue)
                {
                    query = query.Where(g => g.Handicap >= HandicapMin.Value);
                }

                if (HandicapMax.HasValue)
                {
                    query = query.Where(g => g.Handicap <= HandicapMax.Value);
                }
            }

            // Apply sorting
            if (!string.IsNullOrEmpty(SortBy))
            {
                query = SortBy switch
                {
                    "Name" => SortDescending ? query.OrderByDescending(g => g.FirstName).ThenByDescending(g => g.LastName) : query.OrderBy(g => g.FirstName).ThenBy(g => g.LastName),
                    "Handicap" => SortDescending ? query.OrderByDescending(g => g.Handicap) : query.OrderBy(g => g.Handicap),
                    _ => query, // Default to no sorting
                };
            }
            int pageSize = 5;
            Golfers = await PaginatedList<Models.Golfer>.CreateAsync(query, pageIndex ?? 1, pageSize);
            
        }
    }
}
