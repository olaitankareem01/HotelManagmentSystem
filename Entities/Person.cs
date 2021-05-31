using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        public int Age { get; set; }

        public string PhoneNo { get; set; }

        protected internal string Password { get; set; }

        public Person() { }
           
     public Person(int id,string firstName, string lastName, string email, int age,string phoneNo,
         string Password)
        {
            this.Id= id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Age = age;
            this.PhoneNo = phoneNo;
            this.Password = Password;
        }

     
            
     
    }
}
