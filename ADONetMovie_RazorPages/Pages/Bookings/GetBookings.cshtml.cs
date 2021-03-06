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
    public class GetBookingsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
        public User User { get; set; }
        IBookingService bookingService { get; set; }
        public GetBookingsModel(IBookingService service)
        {
            bookingService = service;
        }

        public void OnGetBookingsByUser(int id)
        {
            Bookings = bookingService.GetBookingsByUserId(id);
        }
        public void OnGetBookingsByRoom(int id)
        {
            Bookings = bookingService.GetBookingsByRoomId(id);
        }
        public void OnGet()
        {
            Bookings = bookingService.GetBookings();
            //get the data of the authorized user
            User = HttpContext.Session.Get<User>("User");
        }
        public async Task<IActionResult> OnPostCancelBookingAsync(Booking id)
        {
            //Deleting a booking
            bookingService.DeleteBooking(id);
            //page reload
            return RedirectToPage();
        }
    }
}
