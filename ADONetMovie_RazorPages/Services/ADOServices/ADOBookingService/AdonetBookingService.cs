using ADONetMovie_RazorPages.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services
{
    public class AdonetBookingService
    {

        private IConfiguration configuration { get; }
        string connectionString;
        public AdonetBookingService() { }
        public AdonetBookingService(IConfiguration config)
        {
            configuration = config;
            connectionString = configuration.GetConnectionString("BookingContext");
        }
        public IEnumerable<Booking> GetBookings()
        {
            List<Booking> lst = new List<Booking>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Select * From BookingRoom";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    ReadData(dataReader, lst);
                }
            }
            return lst;
        }

        private void ReadData(SqlDataReader dataReader, List<Booking> sList)
        {
            while (dataReader.Read())
            {
                Booking Booking = new Booking();
                Booking.BookingId = Convert.ToInt32(dataReader["Id"]);
                Booking.RoomId = Convert.ToInt32(dataReader["RoomId"]);
                Booking.UserId = Convert.ToInt32(dataReader["UserId"]);
                Booking.Time = Convert.ToDateTime(dataReader["Time"]);
                sList.Add(Booking);
            }
        }

        public void AddBooking(Room room, User user, DateTime dateTime)
        {
            string sql = $"Insert Into BookingRoom ( RoomId , Time, UserId) Values ( @RoomId, @Time, @UserId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@RoomId", room.RoomId);
                    command.Parameters.AddWithValue("@Time", dateTime);
                    command.Parameters.AddWithValue("@UserId", user.UserId);
                    int affectedRows = command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteBooking(Booking booking)
        {
            string sql = $"Delete From BookingRoom Where Id=@aid";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@aid", booking.BookingId);
                    int affectedRows = command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Booking> GetBookingsByUserId(int id)
        {
            List<Booking> lst = new List<Booking>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Select * From BookingRoom  Where UserId =@aid";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@aid", id);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    ReadData(dataReader, lst);
                }
            }
            return lst;
        }
        public IEnumerable<Booking> GetBookingsByRoom(int id)
        {
            List<Booking> lst = new List<Booking>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Select * From BookingRoom Where RoomId =@aid";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@aid", id);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    ReadData(dataReader, lst);
                }
            }
            return lst;
        }


    }
}
