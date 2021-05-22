using ADONetMovie_RazorPages.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services
{
    public class AdonetMovieService
    {
         private IConfiguration configuration { get; }
        string connectionString;
        public AdonetMovieService(IConfiguration config)
        {
            configuration = config;
            connectionString = configuration.GetConnectionString("CinemaContext");
        }
       
        public List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>();
            string sql = "Select * From Movie ";
             using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    ReadData(dataReader, movies);
                }
            }
            return movies;
        }

        private void ReadData(SqlDataReader dataReader, List<Movie> mList)
        {
             while (dataReader.Read())
                {
                    Movie movie = new Movie();
                    movie.Id = Convert.ToInt32(dataReader["Id"]);
                    movie.Title = Convert.ToString(dataReader["Title"]);
                    movie.RunningTimeInMins = Convert.ToInt32(dataReader[3]);
                    movie.Year = Convert.ToInt32(dataReader["Year"]);
                    movie.StudioId = Convert.ToInt32(dataReader["StudioId"]);
                    movie.ActorId = dataReader.IsDBNull(dataReader.GetOrdinal("ActorId")) ? -1 : Convert.ToInt32(dataReader["ActorId"]);
                    mList.Add(movie);
                }         
        }

        public Movie GetMovieById(int id)
        {
            Movie movie = new Movie();
            string sql = "Select * From Movie where id=@id ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        movie.Id = Convert.ToInt32(dataReader["Id"]);
                        movie.Title= Convert.ToString(dataReader["Title"]);
                        movie.Year = Convert.ToInt32(dataReader["Year"]);
                        movie.RunningTimeInMins = Convert.ToInt32(dataReader["RunningTimeInMins"]);
                        movie.StudioId = Convert.ToInt32(dataReader["StudioId"]);
                        movie.ActorId = dataReader.IsDBNull(dataReader.GetOrdinal("ActorId")) ? -1 : Convert.ToInt32(dataReader["ActorId"]);
                    }
                }
                return movie;
            }
        } 
        
        public   IEnumerable<Movie>   GetMoviesByActor(int aid)
        {
            List<Movie> movies = new List<Movie>();
            string sql = "Select * From Movie where ActorId=@id ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", aid);
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {                   
                        ReadData(dataReader, movies);
                     }
                }               
            }
            return movies;

        }

        public IEnumerable<Movie> GetMoviesByStudio(int sid)
        {
            List<Movie> movies = new List<Movie>();
            string sql = "Select * From Movie where StudioId=@id ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", sid);
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    { 
                        ReadData(dataReader, movies);
                    }
                }
            }
            return movies;

        }
        public void AddMovie(Movie movie)
        {
            string sql = $"Insert Into Movie (Id, Title , Year, StudioId, ActorId) Values (@Id, @Title, @Year, @StudioId, @ActorId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", movie.Id);
                    command.Parameters.AddWithValue("@Title", movie.Title);
                    command.Parameters.AddWithValue("@Year", movie.Year);
                    command.Parameters.AddWithValue("@StudioId", movie.StudioId);
                    command.Parameters.AddWithValue("@ActorId", movie.ActorId);
                    int affectedRows = command.ExecuteNonQuery();
                }
            }
        }
    }
}
