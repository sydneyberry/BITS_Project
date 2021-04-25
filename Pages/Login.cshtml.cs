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

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(Username == null || Password == null)
            {
                Msg = "Invalid Login! Please try again.";
                return Page();
            }

            if (Username.Equals("123456") && Password.Equals("abc"))
            {
                HttpContext.Session.SetString("username", Username);
                return RedirectToPage("EmployeeHomepage");
            }
            else
            {
                Msg = "Invalid Login! Please try again.";
                return Page();
            }
        }


    }
}
