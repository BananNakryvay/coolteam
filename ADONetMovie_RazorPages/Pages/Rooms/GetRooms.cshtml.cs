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

        IRoomService roomService { get; set; }
        IBookingService bookingService { get; set; }
        public GetRoomsModel(IRoomService service, IBookingService bservice)
        {
            roomService = service;
            bookingService = bservice;
        }
        public void OnGet()
        {
            //if (!String.IsNullOrEmpty(FilterCriteria))
            //{
            //    Movies = movieService.GetMovies(FilterCriteria);
            //}
            //else
            Rooms = roomService.GetRooms();
            Rooms.Where(w => bookingService.GetBookingsByRoomId(w.RoomId).Where(t => GetH(t.Time)).Count() > 0).ToList().ForEach(s => s.Status = true);
        }
        public bool GetH(DateTime dateTime)
        {
            double h = DateTime.Now.Subtract(dateTime).TotalHours;
            return ((h<2)&&(h>=0));
        }
    }
}
