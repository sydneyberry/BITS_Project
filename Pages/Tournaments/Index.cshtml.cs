using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BITS_Project.Data;
using BITS_Project.Models;

namespace BITS_Project.Pages.Tournaments
{
    public class IndexModel : PageModel
    {
        private readonly BITS_Project.Data.TournamentContext _context;

        public IndexModel(BITS_Project.Data.TournamentContext context)
        {
            _context = context;
        }

        public IList<Tournament> Tournament { get;set; }

        public async Task OnGetAsync()
        {
            Tournament = await _context.Tournaments.ToListAsync();
        }
    }
}
