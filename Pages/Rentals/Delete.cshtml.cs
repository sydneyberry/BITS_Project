using BITS_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BITS_Project.Pages.Rentals
{
    public class DeleteModel : PageModel
    {
        private readonly BITS_Project.Data.BitsContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(BITS_Project.Data.BitsContext context,
                           ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Rental Rental { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            Rental = await _context.Rentals
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Rental == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("Delete {ID} failed. Try again", id);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals.FindAsync(id);

            if (rental == null)
            {
                return NotFound();
            }

            try
            {
                _context.Rentals.Remove(rental);
                await _context.SaveChangesAsync();
                return RedirectToPage("../Confirmation");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);
                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}