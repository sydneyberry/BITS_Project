using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;


namespace BITS_Project.Pages
{
    public class EmployeeHomepageModel : PageModel
    {
        public string Username { get; set; }
        public int SignedIn { get; set; }

        public void OnGet()
        {
            Username = HttpContext.Session.GetString("username");
            SignedIn = (int)HttpContext.Session.GetInt32("signed_in");
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("signed_in");
            return RedirectToPage("Index");
        }
    }
}
