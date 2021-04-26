﻿using BITS_Project.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BITS_Project.Pages.Rentals
{
    public class EquipmentNamePageModel : PageModel
    {
        public SelectList EquipmentNameSL { get; set; }

        public void PopulateEquipmentsDropDownList(BitsContext _context,
            object selectedDepartment = null)
        {
            var departmentsQuery = from d in _context.Equipments
                                   orderby d.ID // Sort by name.
                                   select d;

            EquipmentNameSL = new SelectList(departmentsQuery.AsNoTracking(),
                        "ID", "EquipmentName", selectedDepartment);
        }
    }
}
