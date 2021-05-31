using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagementSystem.Entities;
using HotelManagementSystem.Repository;

namespace HotelManagementSystem.Services
{
    class PaymentService
    {
        BookingService Bs = new BookingService();

        PaymentRepository PaymentRepo = new PaymentRepository();

        private string GeneratePaymentRef(int length)
        {
            Random rand = new Random();
            string chars = "abcdefghijklmnopqrst012345678910uvwxyz";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[rand.Next(s.Length)]).ToArray());
        }


        public string MakePayment(int Id, string BookingRef, string Email, double amount)
        {
            Booking Booked = Bs.FindBooking(BookingRef);

            string PaymentRef = GeneratePaymentRef(10);
            DateTime CurrentDate = DateTime.UtcNow;
            string PaymentDate = CurrentDate.ToString();
            bool status = true;
            var PaymentMade = PaymentRepo.Create(Id, PaymentRef, Booked, amount, PaymentDate, status);
            if (PaymentMade != null)
            {
                return $"The payment was successful and your payment Reference is {PaymentRef}";

            }
            return "Payment Not successful";
        }

        public Payment FindPaymentByRef(string PaymentRef)
        {
            Payment result = PaymentRepo.Find(PaymentRef);

            if (result != null)
            {
                return result;
            }
            return null;
        }


        public string DisplayAllPayment()
        {
            List<Payment> payments = PaymentRepo.GetAll();

            Console.WriteLine("Here is the List of All  Payments");
            foreach (var payment in payments)
            {
                return $"{payment.paymentRef}\t{payment.Amount}\t {payment.booking.customer.Email}\t{payment.Date}";

            }
            return "No payment Records";
        }

    }
}

