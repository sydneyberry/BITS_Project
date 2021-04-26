using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BITS_Project.Data;
using BITS_Project.Models;

namespace BITS_Project.Pages.Rentals
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
        public Rental Rental { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyRental = new Rental();

            if (await TryUpdateModelAsync<Rental>(
                emptyRental,
                "Rental",
                r => r.FirstName, r => r.LastName, r => r.Equipments, r => r.PhoneNumber))
            {
                Console.WriteLine("testing!");
                _context.Rentals.Add(emptyRental);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");   // make a modal show up
            }

            return Page();      // need to add error messages
        }
    }
}
