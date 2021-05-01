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

namespace BITS_Project.Pages.Tournaments
{
    public class IndexModel : SpaceNamePageModel
    {
        public readonly BITS_Project.Data.BitsContext _context;
        public int SignedIn { get; set; }

        public IndexModel(BITS_Project.Data.BitsContext context)
        {
            _context = context;
        }

        public IList<Tournament> Tournament { get;set; }

        public async Task OnGetAsync()
        {
            if (HttpContext.Session.GetInt32("signed_in").GetValueOrDefault() == 0)
            {
                SignedIn = 0;
            }
            else
            {
                SignedIn = (int)HttpContext.Session.GetInt32("signed_in");
            }
            Tournament = await _context.Tournaments.ToListAsync();
        }

        public string GetSpaceName(BitsContext _context, int space_id)
        {
            /*var query = from x in _context.Spaces
                        where x.ID == space_id
                        select x.type;
            // just you space_id ?
            var type = query.FirstOrDefault();
            switch (query.FirstOrDefault())
            {
                case SpaceType.SMALL_FIELD_1:
                    return "Small Field 1";
                case SpaceType.SMALL_FIELD_2:
                    return "Small Field 2";
                case SpaceType.MEDIUM_FIELD_1:
                    return "Medium Field 1";
                case SpaceType.MEDIUM_FIELD_2:
                    return "Medium Field 2";
                case SpaceType.LARGE_FIELD:
                    return "Large Field";
                case SpaceType.BATTING:
                    return "Batting Cage Area";
                case SpaceType.TRACK:
                    return "Track";
                default:
                    return "Other";
            }*/

            switch (space_id)
            {
                case (int)SpaceType.SMALL_FIELD_1:
                    return "Small Field 1";
                case (int)SpaceType.SMALL_FIELD_2:
                    return "Small Field 2";
                case (int)SpaceType.MEDIUM_FIELD_1:
                    return "Medium Field 1";
                case (int)SpaceType.MEDIUM_FIELD_2:
                    return "Medium Field 2";
                case (int)SpaceType.LARGE_FIELD:
                    return "Large Field";
                case (int)SpaceType.BATTING:
                    return "Batting Cage Area";
                case (int)SpaceType.TRACK:
                    return "Track";
                default:
                    return "Other";
            }

        }
    }
}
