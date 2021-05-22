
using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services.Interfaces;
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
        public void AddRoom(Room Room)
        {
              adonetRoomService.AddRoom(Room);
        }
        public IEnumerable<Room> GetRooms()
        {
            return adonetRoomService.GetRooms().ToList();
        }
        public Room GetRoomById(int id)
        {
            return adonetRoomService.GetRoomById(id);
        }
        public IEnumerable<Room> GetRooms( string  hqcity, string name)
        {
           return adonetRoomService.GetRooms(hqcity, name);
        }
    }
}
