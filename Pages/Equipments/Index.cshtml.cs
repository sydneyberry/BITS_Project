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
    public class IndexModel : PageModel
    {
        private readonly BITS_Project.Data.EquipmentContext _context;

        public IndexModel(BITS_Project.Data.EquipmentContext context)
        {
            _context = context;
        }

        public IList<Equipment> Equipment { get;set; }

        public async Task OnGetAsync()
        {
            Equipment = await _context.Equipments.ToListAsync();
        }
    }
}
