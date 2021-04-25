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
    public class IndexModel : PageModel
    {
        private readonly BITS_Project.Data.RentalContext _context;

        

        public IndexModel(BITS_Project.Data.RentalContext context)
        {
            _context = context;
        }

        public IList<Rental> Rental { get;set; }

        public async Task OnGetAsync()
        {
            Rental = await _context.Rentals.ToListAsync();
        }
    }
}
