using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagementSystem.Services;
using HotelManagementSystem.Entities;

namespace HotelManagementSystem.Controllers
{
    class RoomController
    {

        RoomService Rs = new RoomService();
        public void  RoomMenu()
        {
            Console.WriteLine(" 1. Create Room \n 2. list Available Rooms\n 3. search for a Room \n 4. Edit a Room Profile \n 0. Back  ");
            int Input = Int16.Parse(Console.ReadLine());
            switch (Input)
            {
                case 1:
                    HandleRoomCreation();
                    break;
                case 2:
                    GetRoomLists();
                    break;
                case 3:
                    FindRoom();
                        break;
                case 0:
                    Program pr = new Program();
                    pr.MainMenu();
                    break;


            }
        }

        public void HandleRoomCreation()
        {
            Console.WriteLine("How many rooms do you want to create? ");
            int NoOfRooms = Int16.Parse(Console.ReadLine());
            Console.WriteLine("what type of room do you want to create?");
            string RoomType = Console.ReadLine();
            Console.WriteLine("Enter a description of the room");
            string Description = Console.ReadLine();
            
            if(NoOfRooms > 1 )
            {
               List<Room> rooms =  Rs.CreateManyRooms(RoomType, Description, NoOfRooms);
                if (rooms != null)
                {
                    Console.WriteLine("These are the rooms created");
                    foreach (var room in rooms)
                    {
                        Console.WriteLine($"{room.Id}\t{room.RoomType}\t{room.Description}");
                    }
                }
                RoomMenu();
               
            }
            else
            {
                if(NoOfRooms == 1)
                {
                    Rs.CreateRoom(RoomType, Description);
                    RoomMenu();
                }
            }
        }

        public void GetRoomLists()
        {
            Rs.DisplayAllRooms();
            RoomMenu();
        }

        public void FindRoom()
        {
            int RoomNo = Int16.Parse(Console.ReadLine());
            Rs.FindRoomByRoomNo(RoomNo);
            RoomMenu();
        }
    }
}
