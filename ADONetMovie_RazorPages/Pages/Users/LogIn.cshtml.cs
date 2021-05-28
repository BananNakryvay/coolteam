using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADONetMovie_RazorPages.Pages.Users
{
    public class LogInModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }

        IUserService userService { get; set; }
        public string Message { get; private set; }

        public LogInModel(IUserService service)
        {
            userService = service;
        }
        public IActionResult OnGet()
        {
            User = HttpContext.Session.Get<User>("User");
            if(User != null)
            {
                return RedirectToPage("../Index");
            }
            return Page();
        }
        public IActionResult OnPostAsync(User user)
        {
          
            User = userService.LogIn(user);
            if (string.IsNullOrEmpty(User.UserName))
            {
                Message = "Wrong Username orr Password";
                return Page();
            }
            HttpContext.Session.Set("User", User);
            return RedirectToPage("../Index");
        }
    }
}
