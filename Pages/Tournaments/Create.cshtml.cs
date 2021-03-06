using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BITS_Project.Data;
using BITS_Project.Models;
using Microsoft.AspNetCore.Http;

namespace BITS_Project.Pages.Tournaments
{
    public class CreateModel : SpaceNamePageModel
    {
        private readonly BITS_Project.Data.BitsContext _context;
        public int SignedIn { get; set; }

        public CreateModel(BITS_Project.Data.BitsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("signed_in").GetValueOrDefault() == 0)
            {
                SignedIn = 0;
            }
            else
            {
                SignedIn = (int)HttpContext.Session.GetInt32("signed_in");
            }

            return Page();
        }

        [BindProperty]
        public Tournament Tournament { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyTourn = new Tournament();

            if(await TryUpdateModelAsync<Tournament>(
                emptyTourn,
                "tournament",
                q => q.DateFor, q => q.ActivityType, q => q.MaxTeams,
                q => q.MaxTeamSize, q => q.MinTeamSize, q => q.SpaceID
                ))
            {
                _context.Tournaments.Add(emptyTourn);
                await _context.SaveChangesAsync();
                return RedirectToPage("../Confirmation");
            }

            return Page();
        }

        public string GetSpaceName(SpaceType space)
        {
            switch (space)
            {
                case SpaceType.Small_Field_1:
                    return "Small Field 1";
                case SpaceType.Small_Field_2:
                    return "Small Field 2";
                case SpaceType.Medium_Field_1:
                    return "Medium Field 1";
                case SpaceType.Medium_Field_2:
                    return "Medium Field 2";
                case SpaceType.Large_Field:
                    return "Large Field";
                case SpaceType.Batting_Cage:
                    return "Batting Cage Area";
                case SpaceType.Track:
                    return "Track";
                default:
                    return "Other";
            }
        }
    }
}
