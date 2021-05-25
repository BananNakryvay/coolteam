using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public DateTime Time { get; set; }
    }
}
