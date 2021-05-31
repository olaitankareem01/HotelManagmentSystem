using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Entities
{
    class Payment
    {
      
        public int Id { get; set; }

        public string paymentRef { get; set; }
        public Booking booking { get; }
        public double Amount { get; set; }

        public string Date { get; set; }

        public bool status { get; set; }

        public Payment(int id,string paymentRef, Booking booking, double amount, string date, bool status)
        {
            this.Id = id;
            this.paymentRef = paymentRef;
            this.booking = booking;
            this.Amount = amount;
            this.Date = date;
            this.status = status;
        }
    }
}
