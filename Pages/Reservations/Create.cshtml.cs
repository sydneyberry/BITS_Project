using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BITS_Project.Data;
using BITS_Project.Models;

namespace BITS_Project.Pages.Reservations
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
        public Reservation Reservation { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
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
                return RedirectToPage("./Index");
            }

            return Page();      // need to add error messages
        }
    }
}
