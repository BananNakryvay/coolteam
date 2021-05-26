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

        IBookingService actorService { get; set; }
        public GetBookingsModel(IBookingService service)
        {
            actorService = service;
        }

        public void OnGetBookingsByUser(User user)
        {
            Bookings = actorService.GetBookingsByUserId(user);
        }
        public void GetBookingsByRoom(Room room)
        {
            Bookings = actorService.GetBookingsByRoomId(room);
        }
        public void OnGet()
        {
            //if (!String.IsNullOrEmpty(FilterCriteria))
            //{
            //    Movies = movieService.GetMovies(FilterCriteria);
            //}
            //else
            Bookings = actorService.GetBookings();
        }
    }
}
