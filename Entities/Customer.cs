using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Entities
{
   public class Customer:Person
    {
        public string address { get; set; }

        public Customer()
        {

        }

        public Customer(int id, string firstName, string lastName, string email, int age, string phoneNo, string Password,string Address) : base(id, firstName, lastName, email, age, phoneNo, Password)
        {
        }
    }

  
}
