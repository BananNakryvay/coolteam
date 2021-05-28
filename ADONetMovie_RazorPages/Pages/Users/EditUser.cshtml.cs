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
    public class EditUserModel : PageModel
    {
        IUserService userService;
        public EditUserModel(IUserService service)
        {
            userService = service;

        }
        [BindProperty]
        public User User { get; set; }

      
        public IActionResult OnGet(int id)
        {
            //the page will not be shown if the user is not an administrator

            User = HttpContext.Session.Get<User>("User");
            if (User != null && User.Role == "Admin")
            {
                User = userService.GetUserById(id);
                return Page();
            }
            else
                return RedirectToPage("../Index");
           
        }
        public async Task<IActionResult> OnPostDeleteUserAsync(User id)
        {
            if (HttpContext.Session.Get<User>("User").UserId == id.UserId)
            {
                HttpContext.Session.Clear();
            }

            userService.DeleteUser(id);
            return RedirectToPage("GetUsers");
        }
        public async Task<IActionResult> OnPostMakeTeacherAsync(User id)
        {
            userService.AddUserAsTeacher(id);
            return RedirectToPage("GetUsers");
        }
        public async Task<IActionResult> OnPostMakeAdminAsync(User id)
        {
            userService.AddUserAsAdmin(id);
            return RedirectToPage("GetUsers");
        }
        public async Task<IActionResult> OnPostMakeStudentAsync(User id)
        {
            userService.DeleteUserAsTeacher(id);
            return RedirectToPage("GetUsers");
        }
    }
}
