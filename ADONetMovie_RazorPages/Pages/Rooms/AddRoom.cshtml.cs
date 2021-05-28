using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADONetMovie_RazorPages.Pages.Rooms
{
    public class AddRoomModel : PageModel
    {
        public Room Room{ get; set; }
        public User User { get; set; }
        IRoomService roomService { get; set; }
        public AddRoomModel(IRoomService service)
        {
            roomService = service;
        }
        public IActionResult OnPostAsync(Room room) 
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            roomService.AddRoom(room);
            return RedirectToPage("GetRooms");
        }
        public IActionResult OnGet()
        {
            User = HttpContext.Session.Get<User>("User");
            if (User != null && User.Role == "Admin")
            {
                return Page();
            }
            else
                return RedirectToPage("../Index");
        }
    }
}
