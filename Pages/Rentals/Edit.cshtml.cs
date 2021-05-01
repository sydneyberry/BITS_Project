using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BITS_Project.Data;
using BITS_Project.Models;
using Microsoft.AspNetCore.Http;

namespace BITS_Project.Pages.Rentals
{
    public class EditModel : EquipmentNamePageModel
    {
        private readonly BITS_Project.Data.BitsContext _context;
        public int SignedIn { get; set; }

        public EditModel(BITS_Project.Data.BitsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rental Rental { get; set; }
        public string Msg { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (HttpContext.Session.GetInt32("signed_in").GetValueOrDefault() == 0)
            {
                SignedIn = 0;
            }
            else
            {
                SignedIn = (int)HttpContext.Session.GetInt32("signed_in");
            }

            if (id == null)
            {
                return NotFound();
            }

            Rental = await _context.Rentals.FindAsync(id);


            if (Rental == null)
            {
                return NotFound();
            }
            PopulateEquipmentsDropDownList(_context);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var RentalToUpdate = await _context.Rentals.FindAsync(id);

            if (RentalToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Rental>(
                RentalToUpdate,
                "Rental",
                s => s.FirstName, s => s.LastName, s => s.PhoneNumber, s => s.DateFor, s=>s.EquipmentID))
            {


                //_context.Rentals.Add(RentalToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("../Confirmation");


                /*var quantityLimit = from x in _context.Equipments
                                    where x.ID == RentalToUpdate.EquipmentID
                                    select x.Quantity;

                var count = from y in _context.Rentals
                            where y.DateFor == RentalToUpdate.DateFor && y.EquipmentID == RentalToUpdate.EquipmentID
                            select y;

                if (count.Count() > quantityLimit.First())
                {
                    var temp = from z in _context.Equipments
                               where z.ID == RentalToUpdate.EquipmentID
                               select z.EquipmentName;

                    Msg = "There are no more of " + temp.First().ToString() + " available. Please select a new item to rent.";

                    PopulateEquipmentsDropDownList(_context, RentalToUpdate.ID);
                    return Page();      // need to add error messages
                }*/
            }

            PopulateEquipmentsDropDownList(_context, RentalToUpdate.ID);
            return Page();      // need to add error messages
        }

        private bool RentalExists(int id)
        {
            return _context.Rentals.Any(e => e.ID == id);
        }
    }
}
