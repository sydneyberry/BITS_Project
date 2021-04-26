using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BITS_Project.Data;
using BITS_Project.Models;

namespace BITS_Project.Pages.Rentals
{
    public class DetailsModel : PageModel
    {
        private readonly BitsContext _context;

        public DetailsModel(BitsContext context)
        {
            _context = context;
        }

        public Rental Rental { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Rental = await _context.Rentals.FirstOrDefaultAsync(m => m.ID == id);
            Rental = await _context.Rentals
                .Include(s => s.EquipmentID)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Rental == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
