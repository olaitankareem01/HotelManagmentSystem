using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagementSystem.Entities;

namespace HotelManagementSystem.Repository
{
    
  public  class CustomerRepository
    {
       public List<Customer> Customers = new List<Customer>();

        public List<Customer> GetAllCustomers()
        {
            return Customers;
        }
        public Customer create(int id, string firstName, string lastName, string email, int age, string phoneNo, string Password,string Address)
        {
            Customer NewCustomer = new Customer(id,firstName,lastName,email,age,phoneNo,Password,Address);
            
            Customers.Add(NewCustomer);
            return NewCustomer;
              
        }
       

       public void DisplayCustomers()
        {
            
            foreach(Customer customer in Customers)
            {
                Console.WriteLine($"{customer.LastName} {customer.FirstName}");
            }
        }

        public Customer Find(string Email)
        {
           
            foreach(Customer el in Customers)
            {
                if (el.Email == Email)
                {
                    return el;
                }
            
            }
            return null;


        }


        
        public bool update(int Id, string FirstName, string LastName, string Email,string Password, int Age, string PhoneNo)
        {
            Customer found = this.Find(Email);
            if (found != null)
            {
                found.FirstName = FirstName;
                found.LastName = LastName;
                found.Email = Email;
                found.Password = Password;
                found.Age = Age;
                found.PhoneNo = PhoneNo;
              
            }
            Console.WriteLine(found);
            Console.WriteLine($"The record {Id} has been upadated");
            return true;

        }

        public bool Delete(Customer customer)
        {
            Customers.Remove(customer);
            Console.WriteLine("deleted");
            return true;
        }
    }
}
