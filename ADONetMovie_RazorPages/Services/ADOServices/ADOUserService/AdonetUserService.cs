using ADONetMovie_RazorPages.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ADONetMovie_RazorPages.Services
{
    public class AdonetUserService
    {
        private IConfiguration configuration { get; }
        string connectionString; 
        public AdonetUserService(IConfiguration config)
        {
            configuration = config;
            connectionString = configuration.GetConnectionString("BookingContext");
        }

        public List<User> GetUsers()
        {
            List<User> lst = new List<User>();
            string sql = "Select * From Users";
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
        public void AddUser(User user)
        {
            string sql = $"Insert Into Users (Name, Role, Password) Values ( @Name, @Role, @Password)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", user.UserName);
                    command.Parameters.AddWithValue("@Role", user.Role);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    int affectedRows = command.ExecuteNonQuery();
                }
            }
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
     
        public void DeleteUserAsTeacher(User User)
        {
            string sql = $"Update User set Role = 'User' where Id=@aid";
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

        public User LogIn(User user)
        {

            User User = new User();
            string sql = $"Select * From Users WHERE Name = {User.UserName} AND  Password = {User.Password}";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        User.UserId = Convert.ToInt32(dataReader["Id"]);
                        User.Role = Convert.ToString(dataReader["Role"]);
                    }
                }
            return User;
            }
        }



    }
}

