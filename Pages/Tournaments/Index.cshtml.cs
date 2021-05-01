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
using Microsoft.AspNetCore.Mvc.Filters;

namespace BITS_Project.Pages.Tournaments
{
    public class IndexModel : SpaceNamePageModel
    {
        public readonly BITS_Project.Data.BitsContext _context;
        public int SignedIn { get; set; }
        public bool filtered { get; set; }

        public IndexModel(BITS_Project.Data.BitsContext context)
        {
            _context = context;
        }

        public IList<Tournament> Tournament { get;set; }

        public async Task OnGetAsync(bool filter)
        {
            if (HttpContext.Session.GetInt32("signed_in").GetValueOrDefault() == 0)
            {
                SignedIn = 0;
            }
            else
            {
                SignedIn = (int)HttpContext.Session.GetInt32("signed_in");
            }
            Console.WriteLine(filtered);
            IQueryable<Tournament> upcomingTourns = from x in _context.Tournaments
                                                    select x;
            if(filter && !filtered)
            {
                upcomingTourns = from x in _context.Tournaments
                                 where x.DateFor > DateTime.Now
                                 select x;
                filtered = true;
            } else
            {
                upcomingTourns = from x in _context.Tournaments
                                 select x;
            }

            Tournament = await upcomingTourns.AsNoTracking().ToListAsync();
        }

        

        public string GetSpaceName(int space_id)
        {
            switch (space_id)
            {
                case (int)SpaceType.Small_Field_1:
                    return "Small Field 1";
                case (int)SpaceType.Small_Field_2:
                    return "Small Field 2";
                case (int)SpaceType.Medium_Field_1:
                    return "Medium Field 1";
                case (int)SpaceType.Medium_Field_2:
                    return "Medium Field 2";
                case (int)SpaceType.Large_Field:
                    return "Large Field";
                case (int)SpaceType.Batting_Cage:
                    return "Batting Cage Area";
                case (int)SpaceType.Track:
                    return "Track";
                default:
                    return "Other";
            }

        }
    }
}
