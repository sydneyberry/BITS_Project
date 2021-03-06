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

namespace BITS_Project.Pages.Rentals
{
    public class CreateModel : EquipmentNamePageModel
    {
        private readonly BitsContext _context;
        public int SignedIn { get; set; }
        public string Msg { get; set; }

        public CreateModel(BitsContext context)
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

                var quantityLimit = from x in _context.Equipments
                            where x.ID == emptyRental.EquipmentID
                            select x.Quantity;
                var count = from y in _context.Rentals
                            where y.DateFor == emptyRental.DateFor && y.EquipmentID == emptyRental.EquipmentID
                            select y;

                if(count.Count() > quantityLimit.First())
                {
                    var temp = from z in _context.Equipments
                               where z.ID == emptyRental.EquipmentID
                               select z.EquipmentName;

                    Msg = "There are no more of " + temp.First().ToString() + " available. Please select a new item to rent.";
                    PopulateEquipmentsDropDownList(_context, emptyRental.ID);
                    return Page();      // need to add error messages
                }

                return RedirectToPage("../Confirmation");   // make a modal show up
            }

            PopulateEquipmentsDropDownList(_context, emptyRental.ID);
            return Page();      // need to add error messages
        }
    }
}
