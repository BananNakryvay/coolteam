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
    public class GetUsersModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public IEnumerable<User> Users { get; set; }
        public User User { get; set; }
        IUserService actorService { get; set; }
        public GetUsersModel(IUserService service)
        {
            actorService = service;
        }
        public void OnGet()
        {
            Users = actorService.GetUsers();
            User = HttpContext.Session.Get<User>("User");
        }

    }
}
