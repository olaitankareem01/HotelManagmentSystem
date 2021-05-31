using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagementSystem.Repository;
using HotelManagementSystem.Entities;


namespace HotelManagementSystem.Services
{
    class CustomerService
    {
        CustomerRepository customerRepo = new CustomerRepository();
        public void CreateCustomer( string FirstName, string LastName, string Email, string Password, int Age, string PhoneNo, string Address)
        {
            int LastId = GetLastId();
            int Id = LastId + 1;
            customerRepo.create(Id, FirstName, LastName, Email, Age, PhoneNo, Password, Address);
            
        }

        public Customer FindCustomerByEmail(string Email)
        {
            var result = customerRepo.Find(Email);

            if (result != null)
            {
                Console.WriteLine(result.Email);
                return result;

            }

            return null;
        }

        public bool UpdateCustomerRecord(int Id, string FirstName, string LastName, string Email, string Password, int Age, string PhoneNo)
        {
            bool result = customerRepo.update(Id, FirstName, LastName, Email, Password, Age, PhoneNo);

            if (result == true)
            {
                return true;
            }
            return false;
        }

        public void DisplayAllCustomers()
        {
            List<Customer> customers = customerRepo.GetAllCustomers();
            Console.WriteLine("here is the list of customers:");
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.Id}\t{customer.Email}\t{customer.FirstName}\t{customer.LastName}");
            }
            Console.WriteLine("No customer record");
        }

        public int GetLastId()
        {
            List<Customer> customers = customerRepo.GetAllCustomers();

          if(customers.Count != 0)
            {
                int index = customers.Count - 1;
                return customers[index].Id;
            }
            else
            {
                return 0;
            }

        }

    }
}
