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

        IBookingService bookingService { get; set; }
        public GetBookingsModel(IBookingService service)
        {
            bookingService = service;
        }

        public void OnGetBookingsByUser(User user)
        {
            Bookings = bookingService.GetBookingsByUserId(user);
        }
        public void GetBookingsByRoom(Room room)
        {
            Bookings = bookingService.GetBookingsByRoomId(room);
        }
        public void OnGet()
        {
            //if (!String.IsNullOrEmpty(FilterCriteria))
            //{
            //    Movies = movieService.GetMovies(FilterCriteria);
            //}
            //else
            Bookings = bookingService.GetBookings();
        }
        public async Task<IActionResult> OnPostCancelBookingAsync(Booking id)
        {
            bookingService.DeleteBooking(id);
            return RedirectToPage();
        }
    }
}
