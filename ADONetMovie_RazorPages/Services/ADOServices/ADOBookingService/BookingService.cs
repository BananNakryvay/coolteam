using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services { 
    public class BookingService : IBookingService
    {
        private AdonetBookingService adonetBookingService { get; set; }
        public BookingService(AdonetBookingService service)
        {
            adonetBookingService = service;
        }

        public void AddBooking(Room room, User user, DateTime dateTime)
        {
            adonetBookingService.AddBooking(room, user, dateTime);
        }

        public void DeleteBooking(Booking booking)
        {
            adonetBookingService.DeleteBooking(booking);
        }

        public IEnumerable<Booking> GetBookings()
        {
            return adonetBookingService.GetBookings().ToList();
        }

        public IEnumerable<Booking> GetBookingsByUserId(int id)
        {
            return adonetBookingService.GetBookingsByUserId(id);
        }

        public IEnumerable<Booking> GetBookingsByRoomId(int id)
         {
            return adonetBookingService.GetBookingsByRoom(id);
        }
    }
}
