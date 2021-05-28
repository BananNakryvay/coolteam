using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADONetMovie_RazorPages.Pages.Bookings
{
    public class CreateBookingModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public string Message { get; set; }

        IRoomService roomService { get; set; }
        IBookingService bookingService { get; set; }
        public CreateBookingModel(IRoomService service, IBookingService bservice)
        {
            roomService = service;
            bookingService = bservice;
        }
        public User User { get; set; }
        public IActionResult OnGet()
        {
            User = HttpContext.Session.Get<User>("User");
            if (User == null )
            {

                return RedirectToPage("../Index");
            }
        

            if (!String.IsNullOrEmpty(FilterCriteria))
            {
                Rooms = roomService.GetRooms();
                Rooms.Where(w => bookingService.GetBookingsByRoomId(w.RoomId).Where(t => GetH(t.Time)).Count() > 0).ToList().ForEach(s => s.Status = true);
                Rooms = Rooms.Where(e => e.Status == false);
            }
            else
            {
                Message = "Select Day and Time";
            }
            return Page();
                
        }
        public bool GetH(DateTime dateTime)
        {
            double h = DateTime.Parse(FilterCriteria).Subtract(dateTime).TotalHours;
            return ((h < 2) && (h >= 0));
        }
        public async Task<IActionResult> OnPostCreateBookingAsync(Room id )
        {
            User user = HttpContext.Session.Get<User>("User");
            bookingService.AddBooking(id, user , DateTime.Parse(FilterCriteria));
            return RedirectToPage("GetBookings");
        }
    }
}
