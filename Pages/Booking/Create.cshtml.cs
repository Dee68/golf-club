using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GolfClub.Data;
using GolfClub.Models;
using Microsoft.EntityFrameworkCore;

namespace GolfClub.Pages.Booking
{
    public class CreateModel : PageModel
    {
        private readonly GolfClub.Data.GolfDbContext _context;

        public CreateModel(GolfClub.Data.GolfDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["GolferId"] = new SelectList(_context.Golfers, "Id", "EmailAddress");
        ViewData["Player1GolferId"] = new SelectList(_context.Golfers, "Id", "EmailAddress");
        ViewData["Player2GolferId"] = new SelectList(_context.Golfers, "Id", "EmailAddress");
        ViewData["Player3GolferId"] = new SelectList(_context.Golfers, "Id", "EmailAddress");
        ViewData["Player4GolferId"] = new SelectList(_context.Golfers, "Id", "EmailAddress");

            return Page();
        }

        [BindProperty]
        public GolfClub.Models.Booking Booking { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid || _context.Bookings == null || Booking == null)
                {
                    return Page();
                }

                // Check if the golfer has already booked on the same day
                bool hasExistingBooking = await _context.Bookings.AnyAsync(b =>
                    b.GolferId == Booking.GolferId &&
                    b.TeeTime.Date == Booking.TeeTime.Date);
                if (hasExistingBooking)
                {
                    //ModelState.AddModelError(string.Empty, "The golfer has already booked a tee time on the same day.");
                    TempData["error"] = "The golfer has already booked a tee time on the same day.";
                    
                    return RedirectToPage();
                    
                }
                // Check if there are already four players booked at the same tee time
                int bookedPlayersCount = await _context.Bookings
                    .CountAsync(b => b.TeeTime == Booking.TeeTime);

                if (bookedPlayersCount >= 4)
                {
                    //ModelState.AddModelError(string.Empty, "The tee time is already fully booked.");
                    TempData["error"] = "The tee time is already fully booked.";

                    return RedirectToPage();
                }
                // Assuming TeeTime is rounded to 15 minutes intervals
                if (Booking.TeeTime.Minute % 15 != 0)
                {
                    //ModelState.AddModelError(string.Empty, "Tee time should be in 15 minutes intervals.");
                    TempData["error"] = "Tee time should be in 15 minutes intervals.";
                    
                    return RedirectToPage();
                }
                _context.Bookings.Add(Booking);
                await _context.SaveChangesAsync();
                TempData["success"] = "Booking created successfully";
                

                return RedirectToPage();
            }
            catch (Exception ex)
            {
                TempData["error"] = $"Something went wrong: {ex}";
                
                return Page();
            }
        }
    }
}
