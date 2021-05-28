using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Models
{
    public class Room
    {

        public int RoomId { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public string Size { get; set; }
        public bool Status { get; set; }
    }
}
