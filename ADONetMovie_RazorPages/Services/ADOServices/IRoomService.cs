using ADONetMovie_RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services.Interfaces
{
    interface IRoomService
    {
        IEnumerable<Room> GetRooms(string hqcity, string name);
        IEnumerable<Room> GetRooms();
        void AddRoom(Room room);
        public Room GetRoomById(int id);
    }
}
