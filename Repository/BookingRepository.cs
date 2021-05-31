using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagementSystem.Entities;
using System.Runtime.InteropServices;

namespace HotelManagementSystem.Repository
{
    class BookingRepository
    {
        List<Booking> Bookings = new List<Booking>();
        public bool Create(int Id,string BookingRef, Customer customer, Room room, string BookingDate,bool IsPaid, string CheckIn, string CheckOut)
        {
            Booking booking = new Booking(Id,BookingRef, customer, room, BookingDate, IsPaid, CheckIn, CheckOut);
            Bookings.Add(booking);
            return true;
        }

        public List<Booking> GetAll()
        {
            return Bookings;
        }

        public bool update( string BookingRef, Booking booking, Customer customer, Room room, string BookingDate, string CheckIn, string Checkout, bool IsPaid)
        {
            var index = Bookings.FindIndex(booking => booking.BookingRef == BookingRef);
            if (index < 0)
            {
                return false;
            }

            Bookings[index] = new Booking(booking.Id, BookingRef, customer, room, BookingDate, IsPaid, CheckIn, Checkout);
            return true;

        }

        public Booking Find(string BookingRef)
        {
            foreach(var booking in Bookings)
            {
                if(booking.BookingRef == BookingRef)
                {
                    return booking;
                }
            }
            return null;
        }

        public Booking UpdateCheckIn(Booking booking, int Id, string BookingRef, Customer customer, Room room, string BookingDate, bool IsPaid, string CheckIn, string CheckOut)
        {
            var Index = Bookings.FindIndex(booking => booking.BookingRef == BookingRef);

            if (Index < 0)
            {
                return null;
            }

            Bookings[Index] = new Booking(Id, BookingRef, customer, room, BookingDate, IsPaid, CheckIn, CheckOut);
            return Bookings[Index];
        }

        public Booking UpdateCheckOut(Booking booking, int Id, string BookingRef, Customer customer, Room room, string BookingDate, bool IsPaid, string CheckIn, string CheckOut)
        {
            var Index = Bookings.FindIndex(booking => booking.BookingRef == BookingRef);

            if (Index < 0)
            {
                return null;
            }

            Bookings[Index] = new Booking(Id, BookingRef, customer, room, BookingDate, IsPaid, CheckIn, CheckOut);
            return Bookings[Index];
        }




        public bool Delete(Booking booking)
        {
            Bookings.Remove(booking);
            return true;
        }

    }
}


/*public bool update(Room room, int Id, int RoomNo, string RoomType, string Description)
{
    var index = Rooms.FindIndex(room => room.RoomNo == RoomNo);
    if (index < 0)
    {
        return false;
    }

    Rooms[index] = new Room(Id, RoomType, RoomNo, Description);

    return true;
*/
/*}*/