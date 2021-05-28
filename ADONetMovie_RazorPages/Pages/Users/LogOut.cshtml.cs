using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADONetMovie_RazorPages.Pages.Users
{
    public class LogOutModel : PageModel
    {
        public IActionResult OnGet()
        {
            //kill session
            HttpContext.Session.Clear();
            return RedirectToPage("../Index");
        }
    }
}
