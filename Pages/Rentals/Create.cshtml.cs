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
    public class CreateModel : EquipmentNamePageModel
    {
        private readonly BitsContext _context;

        public CreateModel(BitsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateEquipmentsDropDownList(_context);

            return Page();
        }

        [BindProperty]
        public Rental Rental { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyRental = new Rental();

            if (await TryUpdateModelAsync<Rental>(
                emptyRental,
                "rental",
               r => r.FirstName, r => r.LastName, r => r.EquipmentID, r => r.PhoneNumber))
            {
                _context.Rentals.Add(emptyRental);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");   // make a modal show up
            }

            PopulateEquipmentsDropDownList(_context, emptyRental.ID);
            return Page();      // need to add error messages
        }
    }
}
