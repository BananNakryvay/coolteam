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
    public class AdonetActorService
    {
        private IConfiguration configuration { get; }
        string connectionString; 
        public AdonetActorService(IConfiguration config)
        {
            configuration = config;
            connectionString = configuration.GetConnectionString("CinemaContext");
        }

        public List<Actor> GetActors()
        {
            List<Actor> lst = new List<Actor>();
            string sql = "Select * From Actor ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Actor actor = new Actor();
                        actor.Id = Convert.ToInt32(dataReader["Id"]);
                        actor.Name = Convert.ToString(dataReader["Name"]);
                        actor.Birth_year = Convert.ToDateTime(dataReader["Birth_year"]);
                        actor.Country = Convert.ToString(dataReader["Country"]);
                        lst.Add(actor);
                    }
                }
            }
            return lst;
        }

        public Actor GetActorById(int aid)
        {
            Actor actor = new Actor();
            string sql = "Select * From Actor  where Id=@id ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", aid);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        actor.Id = Convert.ToInt32(dataReader["Id"]);
                        actor.Name = Convert.ToString(dataReader["Name"]);
                        actor.Country = Convert.ToString(dataReader["Country"]);
                        actor.Birth_year = Convert.ToDateTime(dataReader["Birth_year"]);
                        actor.Alive = Convert.ToBoolean(dataReader["Alive"]);
                    }
                }
                return actor;
            }
        }
        public void DeleteActor(Actor actor)
        {
            string sql = $"Delete From Actor Where Id=@aid";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                      command.Parameters.AddWithValue("@aid", actor.Id);
                       int affectedRows = command.ExecuteNonQuery();
                }
            }
        }
    }
}

