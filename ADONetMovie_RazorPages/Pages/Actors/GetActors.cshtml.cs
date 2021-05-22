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
    public class GetActorsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public IEnumerable<Actor> Actors{ get; set; }

        IActorService actorService { get; set; }
        public GetActorsModel(IActorService service)
        {
            actorService = service;
        }
        public void OnGet()
        {
            //if (!String.IsNullOrEmpty(FilterCriteria))
            //{
            //    Movies = movieService.GetMovies(FilterCriteria);
            //}
            //else
            Actors = actorService.GetActors();
        }

        public void OnGetMovies(int aid)
        {

        }
        public void OnPost()
        {

        }
    }
}