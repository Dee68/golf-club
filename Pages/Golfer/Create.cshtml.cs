using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GolfClub.Data;
using GolfClub.Models;

namespace GolfClub.Pages.Golfer
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
            return Page();
        }

        [BindProperty]
        public GolfClub.Models.Golfer Golfer { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Golfers == null || Golfer == null)
            {
                return Page();
            }

            try
            {
                _context.Golfers.Add(Golfer);
                await _context.SaveChangesAsync();
                TempData["success"] = "Golfer created successfully";
            }
            catch (Exception ex)
            {
                TempData["error"] = $"Error has occured: {ex}";
            }


            return RedirectToPage();
        }
    }
}
