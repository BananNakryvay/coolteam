using ADONetMovie_RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services
{
    public interface IRoomService
    {
       
        IEnumerable<Room> GetRooms();
        void DeleteRoom(Room room);
        void AddRoom(Room room);
    }
}
