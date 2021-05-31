using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagementSystem.Entities;
using HotelManagementSystem.Repository;
using System.Runtime.InteropServices;
using System.Reflection;

namespace HotelManagementSystem.Services
{
    public class BookingService
    {
        BookingRepository BookRepo = new BookingRepository();
        CustomerService Cs = new CustomerService();
        RoomService Rs = new RoomService();

        private string GenerateBookingRef(int length)
        {
            Random rand = new Random();
            string chars = "abcdefghijklmnopqrst012345678910uvwxyz";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[rand.Next(s.Length)]).ToArray());
        }

        public string MakeBooking(string Email, int RoomNo)
        {
            int LastId = GetLastId();
            int Id = LastId + 1;
            string BookingRef = GenerateBookingRef(7);
            Room room = Rs.FindRoomByRoomNo(RoomNo);
            Customer customer = Cs.FindCustomerByEmail(Email);
            DateTime CurrentDate = DateTime.UtcNow;
            string BookingDate = CurrentDate.ToString();
            string CheckIn = null;
            string CheckOut = null;

            var RoomBooked = BookRepo.Create(Id: Id, BookingRef: BookingRef, customer: customer, room: room, BookingDate: BookingDate, IsPaid: false, CheckIn: CheckIn, CheckOut: CheckOut);

            if (RoomBooked == true)
            {
                Console.WriteLine($"booking was made successfully with the reference {BookingRef}");
            }
            return null;
        }


        public int GetLastId()
        {
            List<Booking> bookings = BookRepo.GetAll();
            if (bookings.Count != 0)
            {
                int index = bookings.Count - 1;
                return bookings[index].Id;
            }
            else
            {
                return 0;
            }

        }

        public string CheckIn(string Email, string BookingRef)
        {


            var booking = BookRepo.Find(BookingRef);

            if (booking.BookingRef == BookingRef && booking.customer.Email == Email)
            {
                DateTime CurrentDate = DateTime.UtcNow;
                string CheckIn = CurrentDate.ToString();
                var UpdatedBooking = BookRepo.UpdateCheckIn(booking, booking.Id, booking.BookingRef, booking.customer, booking.room, booking.BookingDate, booking.IsPaid, CheckIn, booking.Checkout);
                if (UpdatedBooking != null)
                {
                    return $"{Email} has been Checked In";
                }
               
            }
            else {

                return "Booking Ref or Email does not exist";

                 }

            return null;

        }


        public string CheckOut(string Email, string BookingRef) {

            var booking = BookRepo.Find(BookingRef);

            if (booking.BookingRef == BookingRef && booking.customer.Email == Email)
            {
                DateTime CurrentDate = DateTime.UtcNow;
                string CheckOut = CurrentDate.ToString();
                var UpdatedBooking = BookRepo.UpdateCheckOut(booking, booking.Id, booking.BookingRef, booking.customer, booking.room, booking.BookingDate, booking.IsPaid, booking.CheckIn, CheckOut);
                if (UpdatedBooking != null)
                {
                    return $"{Email} has been Checked Out  ";
                }

            }
            else
            {

                return "Booking Ref or Email does not exist";

            }
            return null;
        }


        public Booking FindBooking(string BookingRef)
        {
            var booking = BookRepo.Find(BookingRef);
            if (booking != null)
            {
                return booking;
            }

            return null;
        }
        public string DeleteBooking(string BookingRef)
        {

            var booking = BookRepo.Find(BookingRef);
            var result = BookRepo.Delete(booking);
            if (result == true)
            {
                return $"The Booking with the reference {BookingRef} has been deleted";
            }
            return null;
        }



        public void DisplayAllBookings()
        {
            var Bookings = BookRepo.GetAll();

            foreach (var booking in Bookings)
            {
                Console.WriteLine(booking.customer);
                Console.WriteLine(booking.customer.Email);

                /*
                var address = GetPropertyValue(GetPropertyValue(emp1, "Address"), "AddressLine1");*/
                /*var Email = GetPropertyValue();*/
                Console.WriteLine($"Booking Ref:{booking.BookingRef}\t Booking Date:{booking.BookingDate}");
            }
        }

    }
}


    

            





    

