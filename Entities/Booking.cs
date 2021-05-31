using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace HotelManagementSystem.Entities
{
  public class Booking
    {

        public int Id { get; set; }
        public string BookingDate { get; set; }
        public string CheckIn{ get; set; }
        public string Checkout { get; set; }
        public bool IsPaid { get; set; }

        public string BookingRef { get; set; }

        public Customer customer { get; set; }

        public Room room { get; set; }

    
       public Booking(int Id,string BookingRef, Customer customer, Room room, string BookingDate, bool IsPaid, string CheckIn, string Checkout)
        {
            this.Id = Id;
            this.customer = customer;
            this.room = room;
            this.BookingDate = BookingDate;
            this.CheckIn = CheckIn;
            this.Checkout = Checkout;
            this.IsPaid = IsPaid;
            this.BookingRef = BookingRef;
           
        }

    }
}
