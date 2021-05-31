using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagementSystem.Services;

namespace HotelManagementSystem.Controllers
{
    class BookingController
    {
        BookingService Bs = new BookingService();
        public void BookingMenu()
        {
            Console.WriteLine("1. Make a reservation \n 2. List Reservations 0. Back");
            int Input = Int16.Parse(Console.ReadLine());
            switch (Input)
            {
                case 1:
                    HandleBookingCreation();
                    break;
                case 2:
                    GetbookingLists();
                    break;
                case 3:
                    FindBooking();
                    break;
                case 0:
                    Program pr = new Program();
                    pr.MainMenu();
                    break;


            }
          
        }


        public void HandleBookingCreation()
        {
            Console.WriteLine("Enter your Email:");
             string Email = Console.ReadLine();
            Console.WriteLine("Enter the Room number you want to book:");
            int RoomNo = Int16.Parse(Console.ReadLine());
            Bs.MakeBooking(Email,RoomNo);
            BookingMenu();

        }

        public void GetbookingLists()
        {
            Bs.DisplayAllBookings();
            BookingMenu();
        }

        public void FindBooking()
        {


        }
    }
}
