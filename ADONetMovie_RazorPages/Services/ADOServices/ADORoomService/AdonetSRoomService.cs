
using ADONetMovie_RazorPages.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
                    ReadData(dataReader, lst);
                }
            }
            return lst;
        }

        private void ReadData(SqlDataReader dataReader, List<Room> sList)
        {
            while (dataReader.Read())
            {
                Room Room = new Room();
                Room.RoomId = Convert.ToInt32(dataReader["Id"]);
                Room.Size = Convert.ToString(dataReader["Size"]);
                Room.Status = Convert.ToBoolean(dataReader["Status"]);
                Room.Copacity = Convert.ToInt32(dataReader["Copacity"]);
                sList.Add(Room);
            }
        }

       
    }
}

