using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADONetMovie_RazorPages.Pages.Users
{
    public class LogInModel : PageModel
    {
        public User User { get; set; }

        IUserService userService { get; set; }
        public LogInModel(IUserService service)
        {
            userService = service;
        }
        public IActionResult OnPostAsync(User user)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            User = userService.LogIn(user);
            HttpContext.Session.Set("User", User);
            return RedirectToPage("GetUsers");
        }
    }
}
