using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BITS_Project.Data;
using BITS_Project.Models;

namespace BITS_Project.Pages.Equipments
{
    public class DetailsModel : PageModel
    {
        private readonly BITS_Project.Data.EquipmentContext _context;

        public DetailsModel(BITS_Project.Data.EquipmentContext context)
        {
            _context = context;
        }

        public Equipment Equipment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Equipment = await _context.Equipments.FirstOrDefaultAsync(m => m.ID == id);

            if (Equipment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
