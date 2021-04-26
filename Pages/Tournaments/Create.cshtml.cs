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
        private readonly BITS_Project.Data.BitsContext _context;

        public CreateModel(BITS_Project.Data.BitsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Tournament Tournament { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyTourn = new Tournament();

            if(await TryUpdateModelAsync<Tournament>(
                emptyTourn,
                "Tournament",
                q => q.DateFor, q => q.ActivityType, q => q.MaxTeams,
                q => q.MaxTeamSize, q => q.MinTeamSize, q => q.Space
                ))
            {
                _context.Tournaments.Add(emptyTourn);
                await _context.SaveChangesAsync();
                return RedirectToPage("../Confirmation");
            }

            return Page();
        }
    }
}
