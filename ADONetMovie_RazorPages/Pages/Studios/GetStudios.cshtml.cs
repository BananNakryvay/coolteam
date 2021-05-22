using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADONetMovie_RazorPages.Pages.Studios
{
    public class GetStudiosModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Studio Studio { get; set; }

        private IStudioService studioService;

        public GetStudiosModel(IStudioService service)
        {
            studioService = service;
        }      
        public IEnumerable<Studio> Studios { get; set; } = new List<Studio>();
        public void OnGet()
        {
            if (!String.IsNullOrEmpty(Studio.Hqcity) || !String.IsNullOrEmpty(Studio.Name))
            {
                Studios = studioService.GetStudios(Studio.Hqcity, Studio.Name);
            }
            else
                Studios = studioService.GetStudios();
        }
        public void OnPost()
        {

        }
    }
}