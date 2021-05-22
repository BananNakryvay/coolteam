using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Models
{
    public class Actor
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime Birth_year { get; set; }
        public bool Alive { get; set; }
    }
}
