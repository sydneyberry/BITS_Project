﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BITS_Project.Data;
using BITS_Project.Models;

namespace BITS_Project.Pages.Reservations
{
    public class DetailsModel : PageModel
    {
        private readonly BITS_Project.Data.ReservationContext _context;

        public DetailsModel(BITS_Project.Data.ReservationContext context)
        {
            _context = context;
        }

        public Reservation Reservation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reservation = await _context.Reservations.FirstOrDefaultAsync(m => m.ID == id);

            if (Reservation == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
