using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADONetMovie_RazorPages.Pages.Movies
{
    public class StudiosActorsByMovieModel : PageModel
    {
        IMovieService movieService;
        IActorService actorService;
        IStudioService studioService;

        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
        public Studio Studio { get; set; }
        public StudiosActorsByMovieModel(IMovieService mservice, IActorService aservice,  IStudioService sservice)
        {
            movieService = mservice;
            actorService = aservice;
            studioService = sservice;
        }
        public void OnGetStudiosActorsPerMovie(int mid,  int sid, int aid)
        {
            Movie = movieService.GetMovieById(mid);
            Actor = actorService.GetActorById(aid);
            Studio = studioService.GetStudioById(sid);
            
        }
    }
}
