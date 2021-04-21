using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BITS_Project.Data;
using BITS_Project.Models;

namespace BITS_Project.Pages.Tournaments
{
    public class CreateModel : PageModel
    {
        private readonly BITS_Project.Data.TournamentContext _context;

        public CreateModel(BITS_Project.Data.TournamentContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Tournament Tournament { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tournaments.Add(Tournament);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
