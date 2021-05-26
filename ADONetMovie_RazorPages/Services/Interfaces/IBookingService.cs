using ADONetMovie_RazorPages.Models;
using System;
using System.Collections.Generic;

namespace ADONetMovie_RazorPages.Services
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetBookings();
        void DeleteBooking(Booking booking);
        void AddBooking(Room room, User user, DateTime dateTime);
        IEnumerable<Booking> GetBookingsByUserId(User user);
        IEnumerable<Booking> GetBookingsByRoomId(Room room);


    }
}
