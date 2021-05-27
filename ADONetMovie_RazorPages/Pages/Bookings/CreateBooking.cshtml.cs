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
        public string Messege { get; set; }

        IRoomService roomService { get; set; }
        IBookingService bookingService { get; set; }
        public CreateBookingModel(IRoomService service, IBookingService bservice)
        {
            roomService = service;
            bookingService = bservice;
        }
        public void OnGet()
        {

            if (!String.IsNullOrEmpty(FilterCriteria))
            {
                Rooms = roomService.GetRooms();
                Rooms.Where(w => bookingService.GetBookingsByRoomId(w.RoomId).Where(t => GetH(t.Time)).Count() > 0).ToList().ForEach(s => s.Status = true);
                Rooms = Rooms.Where(e => e.Status == false);
            }
            else
            {
                Messege = "Select Day and Time";
            }
                
        }
        public bool GetH(DateTime dateTime)
        {
            double h = DateTime.Parse(FilterCriteria).Subtract(dateTime).TotalHours;
            return ((h < 2) && (h >= 0));
        }
        public async Task<IActionResult> OnPostCreateBookingAsync(Room id, User user)
        {
            bookingService.AddBooking(id, user, DateTime.Parse(FilterCriteria));
            return RedirectToPage("GetBookings");
        }
    }
}
