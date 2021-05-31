using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagementSystem.Services;
using HotelManagementSystem.Entities;

namespace HotelManagementSystem.Controllers
{
    class CustomerController
    {
        CustomerService cs = new CustomerService();

        public void CustomerMenu()
        {
            Console.WriteLine("please, choose one of the following options:");
            Console.WriteLine("1. Register Customer" + "\n" + "2. Search Customer" + "\n" + "3. Edit Customer Record" + "\n" + "4. Delete Customer's record" + "\n" + "5.list Customers \n 0. Back");
            int Input = Int32.Parse(Console.ReadLine());
            if (Input == 1)
            {
                RegisterCustomer();
            }
            else if(Input == 2)
            {
                SearchCustomer();
                CustomerMenu();
            }
            else if(Input == 3)
            {
                EditCustomer();

            }
            else if (Input == 4)
            {
                DeleteCustomer();
            }
            else if (Input == 5)
            {
                listCustomers();
            }
            else if(Input == 0)
            {
                 
                 Program pr = new Program();
                pr.MainMenu();
                
            }
        }

       public void RegisterCustomer()
        {
            Console.WriteLine("Enter Customer's First Name");
            string FirstName =  Console.ReadLine();
            Console.WriteLine("Enter Customer's last name");
            string LastName = Console.ReadLine();
            Console.WriteLine("Enter Customer's Email");
            string Email = Console.ReadLine();
            Console.WriteLine("Enter Customer's Password");
            string password = Console.ReadLine();
            Console.WriteLine("Enter Customer's address");
            string Address = Console.ReadLine();
            Console.WriteLine("Enter Customer's age");
            int Age = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter Customer's Phone Number");
            string PhoneNo = Console.ReadLine();
            Random rand = new Random();
            int Id = rand.Next(1, 10);
            cs.CreateCustomer( FirstName, LastName, Email, password, Age, PhoneNo,Address);
            CustomerMenu();
         
        }


        public string SearchCustomer()
        {
            Console.WriteLine("Enter the Customer's Email");
            string Email = Console.ReadLine();
            Customer customer = cs.FindCustomerByEmail(Email);
            if(customer!= null)
            {
                return $"{customer.Id}\t{customer.Email}\t{customer.FirstName}\t{customer.LastName}";
            }
            else
                {
                return "Customer Record Not found";
            }
           
        }
        public void listCustomers()
        {
            cs.DisplayAllCustomers();
            CustomerMenu();
        }
        public void EditCustomer()
        {
            Console.WriteLine("Enter the customer's email");
            string email =   Console.ReadLine();
       /*     bool result = cs.FindCustomerByEmail(email);*/
            
        }
        public void DeleteCustomer()
        {

        }


    }
}
