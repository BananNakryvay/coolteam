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
        public GetRoomsModel(IRoomService service)
        {
            roomService = service;
        }
        public void OnGet()
        {
            //if (!String.IsNullOrEmpty(FilterCriteria))
            //{
            //    Movies = movieService.GetMovies(FilterCriteria);
            //}
            //else
            Rooms = roomService.GetRooms();
        }
    }
}
