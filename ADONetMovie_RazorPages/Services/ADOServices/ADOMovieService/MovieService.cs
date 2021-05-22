
using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services
{
    public class MovieService : IMovieService
    {
      
        private AdonetMovieService movieService;
         public MovieService(AdonetMovieService service)
        {
             movieService = service;
        }
        public void AddMovie(Movie movie)
        {
            movieService.AddMovie(movie);
        }
        public IEnumerable<Movie> GetMovies()
        {
            return movieService.GetMovies();         
        }
        public Movie GetMovieById(int mid)
        {
            return movieService.GetMovieById(mid);
        }

        public IEnumerable<Movie> GetMoviesByActor(int aid)
        {
            return movieService.GetMoviesByActor( aid);
        }
        public IEnumerable<Movie> GetMoviesByStudio(int sid)
        {
            return movieService.GetMoviesByStudio(sid);
        }
       
    }
}
