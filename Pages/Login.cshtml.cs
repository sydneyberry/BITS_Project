using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BITS_Project.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Msg { get; set; }

        public int SignedIn { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(Username == null || Password == null)
            {
                Msg = "Invalid Login! Please try again.";
                SignedIn = 0;
                return Page();
            }

            if (Username.Equals("123456") && Password.Equals("abc"))
            {
                SignedIn = 1;
                HttpContext.Session.SetString("username", Username);
                HttpContext.Session.SetInt32("signed_in", SignedIn);
                
                return RedirectToPage("EmployeeHomepage");
            }
            else
            {
                Msg = "Invalid Login! Please try again.";
                SignedIn = 0;
                return Page();
            }
        }
    }
}
