using ADONetMovie_RazorPages.Models;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Xunit;

namespace BookingUnitTest
{
    public class CountList
    {
        [Fact]
        public void ListAdding()
        {
            //arrange

            List<Booking> sList = new List<Booking>();
            Booking booking = new Booking() { BookingId = 1, RoomId = 2, UserId = 3, Time = new DateTime(2008, 3, 1, 7, 0, 0) };
            Booking booking2 = new Booking() { BookingId = 2, RoomId = 4, UserId = 6, Time = new DateTime(2009, 4, 2, 9, 0, 0) };

            //act
            sList.Add(booking);
            sList.Add(booking2);
            //assert

            Assert.Equal(2, sList.Count);

        }
        [Fact]
        public void GetBookingsByRoomId()
        {
            //arrange

            List<Booking> sList = new List<Booking>();
            Booking booking = new Booking() { BookingId = 1, RoomId = 2, UserId = 3, Time = new DateTime(2008, 3, 1, 7, 0, 0) };
            Booking booking2 = new Booking() { BookingId = 2, RoomId = 4, UserId = 6, Time = new DateTime(2009, 4, 2, 9, 0, 0) };
            Booking booking3 = new Booking() { BookingId = 3, RoomId = 4, UserId = 5, Time = new DateTime(2010, 4, 2, 9, 0, 0) };
            Booking booking4 = new Booking() { BookingId = 4, RoomId = 4, UserId = 4, Time = new DateTime(2009, 5, 2, 9, 0, 0) };
            Booking booking5 = new Booking() { BookingId = 5, RoomId = 5, UserId = 2, Time = new DateTime(2009, 2, 2, 9, 0, 0) };

            List<Booking> newList = new List<Booking>();
            //act
            sList.Add(booking);
            sList.Add(booking2);
            sList.Add(booking3);
            sList.Add(booking4);
            sList.Add(booking5);

            //act2

            foreach (var item in sList)
            {
                if(item.RoomId == 4)
                {
                    newList.Add(item);
                }
            }

            //assert

            Assert.Equal(3, newList.Count);

        }



    }
}
