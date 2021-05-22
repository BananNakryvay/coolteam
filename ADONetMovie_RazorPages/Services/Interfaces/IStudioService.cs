using ADONetMovie_RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services.Interfaces
{
    public interface IStudioService
    {
       IEnumerable<Studio> GetStudios(string hqcity, string name);
        IEnumerable<Studio> GetStudios();
        void  AddStudio(Studio studio);
        public Studio  GetStudioById(int id);       
    }
}
