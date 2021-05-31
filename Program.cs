using System;
using HotelManagementSystem.Repository;
using HotelManagementSystem.Services;
using HotelManagementSystem.Controllers;
using HotelManagementSystem.Entities;

namespace HotelManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            Program pr = new Program();
            pr.MainMenu();

        }

        public void MainMenu()
        {
            Console.WriteLine("please, select one of the following option:");
            Console.WriteLine("1. Customer Management Menu \n 2. Room Management Menu \n 3. Payment Management Menu \n 4. Booking management menu");
            int option = Int32.Parse(Console.ReadLine());
            if (option == 1)
            {
                CustomerController cc = new CustomerController();
                cc.CustomerMenu();
            }
            else if (option == 2)
            {
                RoomController Rc = new RoomController();
                Rc.RoomMenu();
            }
            else if(option == 4)
            {
                BookingController Bc = new BookingController();
                Bc.BookingMenu();
            }
        }
    }
}
