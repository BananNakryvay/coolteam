
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
    public class AdonetRoomService
    {        
       private IConfiguration configuration { get; }
        string connectionString;
        public AdonetRoomService() { }
        public AdonetRoomService(IConfiguration config)
        {
            configuration = config;
            connectionString = configuration.GetConnectionString("CinemaContext");
        }
        public IEnumerable<Room> GetRooms()
        {
            List<Room> lst = new List<Room>();       
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Select * From Room";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    ReadData(dataReader , lst);
                }
         }
         return lst;
     }

        private void  ReadData (SqlDataReader dataReader , List<Room> sList)
        {
            while (dataReader.Read())
            {
                Room Room = new Room();
                Room.RoomId = Convert.ToInt32(dataReader["Id"]);
                Room.Size = Convert.ToString(dataReader["Size"]);
                Room.Status = Convert.ToBoolean(dataReader["Status"]);
                Room.Time = Convert.ToDateTime(dataReader["Time"]);
                Room.Copacity = Convert.ToInt32(dataReader["Copacity"]);
                sList.Add(Room);
            }
        }
        public IEnumerable<Room> GetRooms(string city , string name)
        {
            string sql;
            List<Room> lst = new List<Room>();
            if (!String.IsNullOrEmpty(city) && String.IsNullOrEmpty(name))
            {
                 sql = $"Select * From Room where HQCity LIKE'{city}%' ";
            }
            else if (!String.IsNullOrEmpty(name) && String.IsNullOrEmpty(city))
            {
                 sql = $"Select * From Room where Name LIKE '{name}%' ";
            }
            else
            {
                sql = $"Select * From Room where (Name LIKE'{name}%'  and   HQCity LIKE'{city}%')";
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

        public Room GetRoomById(int id)
        {
            Room Room = new Room();
            string sql = "Select * From Room  where Id=@id ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                 connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Room.RoomId = Convert.ToInt32(dataReader["Id"]);
                        Room.Size = Convert.ToString(dataReader["Size"]);
                        Room.Status = Convert.ToBoolean(dataReader["Status"]);
                        Room.Time = Convert.ToDateTime(dataReader["Time"]);
                        Room.Copacity = Convert.ToInt32(dataReader["Copacity"]);
                    }
                }
                return Room;
            }
        }
        public void AddRoom(Room Room)
        {
            string sql = $"Insert Into Room(Name, HQCity, NoOfEmployees) Values (@Name,@HQCity, @NumberOfPeople)";
            using (SqlConnection connection = new SqlConnection())
            {
                 connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Size", Room.Size);
                    command.Parameters.AddWithValue("@Status", Room.Status);
                    command.Parameters.AddWithValue("@Time", Room.Time);
                    command.Parameters.AddWithValue("@Copacity", Room.Copacity);
                    int affectedRows = command.ExecuteNonQuery();
                }
            }
        }
    }
}

