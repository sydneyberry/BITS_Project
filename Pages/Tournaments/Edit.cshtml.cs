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

namespace BITS_Project.Pages.Tournaments
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
        public Tournament Tournament { get; set; }

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

            Tournament = await _context.Tournaments.FindAsync(id);

            if (Tournament == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var TournToUpdate = await _context.Tournaments.FindAsync(id);

            if(TournToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Tournament>(
                TournToUpdate,
                "Tournament",
                 t => t.DateFor, t => t.ActivityType, t => t.MaxTeams, 
                 t => t.MaxTeamSize, t => t.MinTeamSize, t => t.SpaceID))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }


            return Page();
        }

        private bool TournamentExists(int id)
        {
            return _context.Tournaments.Any(e => e.ID == id);
        }
    }
}
