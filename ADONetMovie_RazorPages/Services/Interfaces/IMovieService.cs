using ADONetMovie_RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services.Interfaces
{
    public interface IMovieService
    {  
        IEnumerable<Movie> GetMoviesByActor(int aid);
        IEnumerable<Movie> GetMoviesByStudio(int sid);
        IEnumerable<Movie> GetMovies();
        Movie GetMovieById(int id);
        void  AddMovie(Movie movie); 
    }
}
