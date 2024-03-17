using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GolfClub.Pages.Booking
{
    public class BookingsForMemberModel : PageModel
    {

        private readonly Data.GolfDbContext _context;

        public BookingsForMemberModel(Data.GolfDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public int SelectedMemberId { get; set; }

        public List<SelectListItem> Members { get; set; }

        public List<GolfClub.Models.Booking> Bookings { get; set; }

        public IActionResult OnGet(int id)
        {
            // Check if SelectedMemberId is provided
            if (id != 0)
            {
                SelectedMemberId = id;
                Bookings = _context.Bookings
                    .Include(b => b.Player1)
                    .Include(b => b.Player2)
                    .Include(b => b.Player3)
                    .Include(b => b.Player4)
                    .Where(b => b.GolferId == SelectedMemberId)
                    .ToList();
            }
            else
            {
                TempData["error"] = "Please select a member to view bookings.";
            }

            Members = _context.Golfers
               .Select(g => new SelectListItem { Value = g.Id.ToString(), Text = $"{g.FirstName} {g.LastName}" })
               .ToList();

            return Page();

        }

        public IActionResult OnPost()
        {
            //Debug.WriteLine("OnPost method called");
            if (SelectedMemberId == 0)
            {
                return Page();
            }
            Bookings = _context.Bookings
                .Include(b => b.Player1)
                .Include(b => b.Player2)
                .Include(b => b.Player3)
                .Include(b => b.Player4)
                .Where(b => b.GolferId == SelectedMemberId)
                .ToList();
            Members = _context.Golfers
               .Select(g => new SelectListItem { Value = g.Id.ToString(), Text = $"{g.FirstName} {g.LastName}" })
               .ToList();

            return Page();
        }
    }
}
