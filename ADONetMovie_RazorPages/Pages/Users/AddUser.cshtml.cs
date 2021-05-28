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
    public class AddUserModel : PageModel
    {
        public User User { get; set; }

        IUserService userService { get; set; }
        public AddUserModel(IUserService service)
        {
            userService = service;
        }
        public IActionResult OnGet()
        {
            User = HttpContext.Session.Get<User>("User");
            if (User != null && User.Role=="Admin")
            {
                return Page();
            }else
            return RedirectToPage("../Index");
        }
        public IActionResult OnPostAsync(User user)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            userService.AddUser(user);
            return RedirectToPage("GetUsers");
        }

    }
}
