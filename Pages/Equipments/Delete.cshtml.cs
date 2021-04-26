using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BITS_Project.Data;
using BITS_Project.Models;
using Microsoft.AspNetCore.Http;

namespace BITS_Project.Pages.Equipments
{
    public class DeleteModel : PageModel
    {
        private readonly BITS_Project.Data.BitsContext _context;
        public int SignedIn { get; set; }

        public DeleteModel(BITS_Project.Data.BitsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Equipment Equipment { get; set; }

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

            Equipment = await _context.Equipments.FirstOrDefaultAsync(m => m.ID == id);

            if (Equipment == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Equipment = await _context.Equipments.FindAsync(id);

            if (Equipment != null)
            {
                _context.Equipments.Remove(Equipment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../Confirmation");
        }
    }
}
