﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Models
{
    public class Room
    {

        public int RoomId { get; set; }
        public int Capacity { get; set; }
        public string Size { get; set; }
        public bool Status { get; set; }
    }
}
