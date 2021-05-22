
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
    public class AdonetStudioService
    {        
       private IConfiguration configuration { get; }
        string connectionString;
        public AdonetStudioService() { }
        public AdonetStudioService(IConfiguration config)
        {
            configuration = config;
            connectionString = configuration.GetConnectionString("CinemaContext");
        }
        public IEnumerable<Studio> GetStudios()
        {
            List<Studio> lst = new List<Studio>();       
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Select * From Studio";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    ReadData(dataReader , lst);
                }
         }
         return lst;
     }

        private void  ReadData (SqlDataReader dataReader , List<Studio> sList)
        {
            while (dataReader.Read())
            {
                Studio studio = new Studio();
                studio.Id = Convert.ToInt32(dataReader["Id"]);
                studio.Name = Convert.ToString(dataReader["Name"]);
                studio.Hqcity = Convert.ToString(dataReader["Hqcity"]);
                studio.NoOfEmployees = Convert.ToInt32(dataReader["NoOfEmployees"]);
                sList.Add(studio);
            }
        }
        public IEnumerable<Studio> GetStudios(string city , string name)
        {
            string sql;
            List<Studio> lst = new List<Studio>();
            if (!String.IsNullOrEmpty(city) && String.IsNullOrEmpty(name))
            {
                 sql = $"Select * From Studio where HQCity LIKE'{city}%' ";
            }
            else if (!String.IsNullOrEmpty(name) && String.IsNullOrEmpty(city))
            {
                 sql = $"Select * From Studio where Name LIKE '{name}%' ";
            }
            else
            {
                sql = $"Select * From Studio where (Name LIKE'{name}%'  and   HQCity LIKE'{city}%')";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    ReadData(dataReader, lst);
                }
            }
            return lst;
        }

        public Studio GetStudioById(int id)
        {
            Studio studio = new Studio();
            string sql = "Select * From Studio  where Id=@id ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                 connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        studio.Id = Convert.ToInt32(dataReader["Id"]);
                        studio.Name = Convert.ToString(dataReader["Name"]);
                        studio.Hqcity= Convert.ToString(dataReader["HQCity"]);
                        studio.NoOfEmployees = Convert.ToInt32(dataReader["NoOfEmployees"]);
                    }
                }
                return studio;
            }
        }
        public void AddStudio(Studio studio)
        {
            string sql = $"Insert Into Studio(Id, Name, HQCity, NoOfEmployees) Values (@id, @Name, @HQCity, @NumberOfPeople)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                 connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", studio.Id);
                    command.Parameters.AddWithValue("@Name", studio.Name);
                    command.Parameters.AddWithValue("@HQCity", studio.Hqcity);
                    command.Parameters.AddWithValue("@NumberOfPeople", studio.NoOfEmployees);
                    int affectedRows = command.ExecuteNonQuery();
                }
            }
        }
    }
}

