
using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services
{
    public class StudioService :IStudioService
    {
        private AdonetStudioService adonetStudioService { get; set; }
        public StudioService(AdonetStudioService service)
        {
            adonetStudioService = service;
        }
        public void AddStudio(Studio studio)
        {
              adonetStudioService.AddStudio(studio);
        }
        public IEnumerable<Studio> GetStudios()
        {
            return adonetStudioService.GetStudios().ToList();
        }
        public Studio GetStudioById(int id)
        {
            return adonetStudioService.GetStudioById(id);
        }
        public IEnumerable<Studio> GetStudios( string  hqcity, string name)
        {
           return adonetStudioService.GetStudios(hqcity, name);
        }
    }
}
