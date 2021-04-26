using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BITS_Project.Data;
using BITS_Project.Models;
using Microsoft.AspNetCore.Http;

namespace BITS_Project.Pages.Rentals
{
    public class EditModel : PageModel
    {
        private readonly BITS_Project.Data.BitsContext _context;
        public int SignedIn { get; set; }

        public EditModel(BITS_Project.Data.BitsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rental Rental { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (HttpContext.Session.GetInt32("signed_in").GetValueOrDefault() == 0)
            {
                SignedIn = 0;
            }
            else
            {
                SignedIn = (int)HttpContext.Session.GetInt32("signed_in");
            }

            if (id == null)
            {
                return NotFound();
            }

            Rental = await _context.Rentals.FindAsync(id);

            if (Rental == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var RentalToUpdate = await _context.Rentals.FindAsync(id);

            if (RentalToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Rental>(
                RentalToUpdate,
                "Rental",
                s => s.FirstName, s => s.LastName, s => s.PhoneNumber, s => s.DateFor))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool RentalExists(int id)
        {
            return _context.Rentals.Any(e => e.ID == id);
        }
    }
}
