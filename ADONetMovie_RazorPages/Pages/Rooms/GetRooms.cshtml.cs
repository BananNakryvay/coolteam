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
    public class GetRoomsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public User User { get; set; }
        IRoomService roomService { get; set; }
        IBookingService bookingService { get; set; }
        public GetRoomsModel(IRoomService service, IBookingService bservice)
        {
            roomService = service;
            bookingService = bservice;
        }
        public void OnGet()
        {
            User = HttpContext.Session.Get<User>("User");
            Rooms = roomService.GetRooms();
            Rooms.Where(w => bookingService.GetBookingsByRoomId(w.RoomId).Where(t => GetH(t.Time)).Count() > 0).ToList().ForEach(s => s.Status = true);
        }
        public bool GetH(DateTime dateTime)
        {
            //booking can be made only if the difference between the interval before another booking is more than 2 hours
            double h = DateTime.Now.Subtract(dateTime).TotalHours;
            return ((h<2)&&(h>-2));
        }

        public async Task<IActionResult> OnPostDelRoomAsync(Room id)
        {
            //Removing a room
            roomService.DeleteRoom(id);
            return RedirectToPage();
        }

    }
}
