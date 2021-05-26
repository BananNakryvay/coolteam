
using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services
{
    public class RoomService :IRoomService
    {
        private AdonetRoomService adonetRoomService { get; set; }
        public RoomService(AdonetRoomService service)
        {
            adonetRoomService = service;
        }
        
        public IEnumerable<Room> GetRooms()
        {
            return adonetRoomService.GetRooms().ToList();
        }

        public void DeleteRoom(Room room)
        {
            adonetRoomService.DeleteRoom(room);
        }

        public void AddRoom(Room room)
        {
            adonetRoomService.AddRoom(room);
        }
    }
}
