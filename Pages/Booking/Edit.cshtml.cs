using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GolfClub.Data;
using GolfClub.Models;

namespace GolfClub.Pages.Booking
{
    public class EditModel : PageModel
    {
        private readonly GolfClub.Data.GolfDbContext _context;

        public EditModel(GolfClub.Data.GolfDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GolfClub.Models.Booking Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking =  await _context.Bookings.FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }
            Booking = booking;
           ViewData["GolferId"] = new SelectList(_context.Golfers, "Id", "EmailAddress");
           ViewData["Player1GolferId"] = new SelectList(_context.Golfers, "Id", "EmailAddress");
           ViewData["Player2GolferId"] = new SelectList(_context.Golfers, "Id", "EmailAddress");
           ViewData["Player3GolferId"] = new SelectList(_context.Golfers, "Id", "EmailAddress");
           ViewData["Player4GolferId"] = new SelectList(_context.Golfers, "Id", "EmailAddress");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Booking).State = EntityState.Modified;

            try
            {
                // Check if the golfer has already booked on the same day
                bool hasExistingBooking = await _context.Bookings.AnyAsync(b =>
                    b.GolferId == Booking.GolferId &&
                    b.TeeTime.Date == Booking.TeeTime.Date);

                if (hasExistingBooking)
                {
                    TempData["error"] = "The golfer has already booked a tee time on the same day.";
                    return Page();
                }

                // Check if there are already four players booked at the same tee time
                int bookedPlayersCount = await _context.Bookings
                    .CountAsync(b => b.TeeTime == Booking.TeeTime);

                if (bookedPlayersCount >= 4)
                {
                    TempData["error"] = "The tee time is already fully booked.";
                    return Page();
                }

                // Assuming TeeTime is rounded to 15 minutes intervals
                if (Booking.TeeTime.Minute % 15 != 0)
                {
                    TempData["error"] = "Tee time should be in 15 minutes intervals.";
                    return Page();
                }

                _context.Attach(Booking).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                TempData["success"] = "Booking updated successfully";

                return RedirectToPage("./Index");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(Booking.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = $"Something went wrong: {ex}";
                return Page();
            }

        }

        private bool BookingExists(int id)
        {
          return (_context.Bookings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
