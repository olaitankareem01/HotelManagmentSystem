using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagementSystem.Entities;

namespace HotelManagementSystem.Repository
{
    class PaymentRepository
    {
        private List<Payment> Payments = new List<Payment>();

        public Payment Create(int Id,string paymentref, Booking booking, double amount, string Date, bool status)
        {
            Payment Payment = new Payment(id: Id, paymentRef: paymentref, booking: booking, amount: amount, date: Date, status);
            Payments.Add(Payment);
            return Payment;
        }

        public List<Payment> GetAll()
        {
            return Payments;
        }
        
        public  bool Update(Payment payment, int Id, string paymentref, Booking booking, double amount, string Date, bool status)
        {
            var index = Payments.FindIndex(payment => payment.paymentRef == paymentref);

            if (index < 0)
            {
                return false;
            }

            Payments[index] = new Payment(Id, paymentref, booking, amount, Date, status);

            return true;
        }


        public Payment Find(string PaymentRef)
        {
            foreach(var payment in Payments)
            {
                if (payment.paymentRef == PaymentRef)
                {
                    return payment;
                }
                
            }
            return null;
        }
        

        public bool Delete(Payment payment)
        {
            Payments.Remove(payment);
            return true;
        }
    }
}
