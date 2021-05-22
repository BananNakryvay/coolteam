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
    public class AdonetUserService
    {
        private IConfiguration configuration { get; }
        string connectionString; 
        public AdonetUserService(IConfiguration config)
        {
            configuration = config;
            connectionString = configuration.GetConnectionString("CinemaContext");
        }

        public List<User> GetUsers()
        {
            List<User> lst = new List<User>();
            string sql = "Select * From User ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        User User = new User();
                        User.UserId = Convert.ToInt32(dataReader["Id"]);
                        User.UserName = Convert.ToString(dataReader["Name"]);
                        User.Role = Convert.ToString(dataReader["Role"]);
                        lst.Add(User);
                    }
                }
            }
            return lst;
        }
        public List<User> GetAllAdminsTeachers()
        {
            List<User> lst = new List<User>();
            string sql = "Select * From User Where (Role LIKE 'Teacher%' or Role LIKE 'Admin%')";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        User User = new User();
                        User.UserId = Convert.ToInt32(dataReader["Id"]);
                        User.UserName = Convert.ToString(dataReader["Name"]);
                        User.Role = Convert.ToString(dataReader["Role"]);
                        lst.Add(User);
                    }
                }
            }
            return lst;
        }

        public void AddUserAsAdmin(User User)
        {
            string sql = $"Update User set Role = 'Admin' where Id=@aid";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@aid", User.UserId);
                    int affectedRows = command.ExecuteNonQuery();
                }
            }
        }
        public void AddUserAsTeacher(User User)
        {
            string sql = $"Update User set Role = 'Teacher' where Id=@aid";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@aid", User.UserId);
                    int affectedRows = command.ExecuteNonQuery();
                }
            }
        }
        public void AddUser(User User)
        {
            string sql = $"Insert Into Studio(Name, HQCity, NoOfEmployees) Values (@Name,@HQCity, @NumberOfPeople)";
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", User.UserName);
                    command.Parameters.AddWithValue("@Passwoed", User.Password);
                    command.Parameters.AddWithValue("@Role", User.Role);
                    int affectedRows = command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteUserAsAdmin(User User)
        {
            string sql = $"Update User set Role = 'Admin' where Id=@aid";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@aid", User.UserId);
                    int affectedRows = command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteUser(User User)
        {
            string sql = $"Delete From User Where Id=@aid";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                      command.Parameters.AddWithValue("@aid", User.UserId);
                       int affectedRows = command.ExecuteNonQuery();
                }
            }
        }
    }
}

