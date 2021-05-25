using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services.ADOServices.ADOBookingService
{
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

        public IEnumerable<Booking> GetBookingsByUserId(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Booking> GetBookingsByRoomId(Room room)
        {
            throw new NotImplementedException();
        }
    }
}
