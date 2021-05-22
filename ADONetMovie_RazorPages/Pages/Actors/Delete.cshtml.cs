using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADONetMovie_RazorPages.Pages.Actors
{
    public class DeleteModel : PageModel
    {
        IActorService actorService;
       public DeleteModel(IActorService service)
        {
            this.actorService = service;
           
        }
        [BindProperty]
        public Actor Actor { get; set; }

        public IActionResult OnGet(int id)
        {
            Actor = actorService.GetActorById(id);
            return Page();
        }
        public IActionResult OnPostAsync()
        {
            actorService.DeleteActor(Actor);
            return RedirectToPage("GetActors");
        }
    }
}
