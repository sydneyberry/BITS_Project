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

namespace BITS_Project.Pages.Reservations
{
    public class CreateModel : PageModel
    {
        public int SignedIn { get; set; }
        private readonly BITS_Project.Data.BitsContext _context;

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
        public Reservation Reservation { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyRev = new Reservation();

            if (await TryUpdateModelAsync<Reservation>(
                emptyRev,
                "Reservation",
                x => x.FirstName, x => x.LastName))
            {
                //SConsole.WriteLine("testing!");
                _context.Reservations.Add(emptyRev);
                await _context.SaveChangesAsync();
                return RedirectToPage("../Confirmation");
            }

            return Page();      // need to add error messages
        }
    }
}
