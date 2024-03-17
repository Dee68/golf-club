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

namespace GolfClub.Pages.Golfer
{
    public class EditModel : PageModel
    {
        private readonly GolfClub.Data.GolfDbContext _context;

        public EditModel(GolfClub.Data.GolfDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GolfClub.Models.Golfer Golfer { get; set; } = default!;
        public List<SelectListItem> GenderOptions { get; } = new List<SelectListItem>
    {
        new SelectListItem { Value = "M", Text = "Male" },
        new SelectListItem { Value = "F", Text = "Female" }
    };

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Golfers == null)
            {
                return NotFound();
            }

            var golfer =  await _context.Golfers.FirstOrDefaultAsync(m => m.Id == id);
            if (golfer == null)
            {
                return NotFound();
            }
            Golfer = golfer;
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

            _context.Attach(Golfer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GolferExists(Golfer.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GolferExists(int id)
        {
          return (_context.Golfers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
