using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BITS_Project.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BITS_Project.Pages.Tournaments
{
    public class SpaceNamePageModel : PageModel
    {
        public SelectList SpaceNameSL { get; set; }

        public void PopulateSpaceDropDownList(BitsContext _context,
            object selectedSpace = null)
        {
            var SpaceQuery = from d in _context.Tournaments
                                    // Sort by name.
                                   select d;

            SpaceNameSL = new SelectList(SpaceQuery.AsNoTracking(),
                        "DepartmentID", "Name", selectedSpace);
        }
    }
}
