using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADONetMovie_RazorPages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Studio Studio { get; set; }
        public void OnGet()
        {
         }
        IStudioService studioService;
        public CreateModel(IStudioService service)
        {
            this.studioService = service;
        }
        public IActionResult OnPostAsync(Studio studio)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            studioService.AddStudio(studio);
            return RedirectToPage("GetStudios");
        }
    }
}