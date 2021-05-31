using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagementSystem.Repository;
using HotelManagementSystem.Entities;

namespace HotelManagementSystem.Services
{
    class RoomService
    {
        RoomRepository RoomRepo = new RoomRepository();

        public void CreateRoom(string RoomType, string Description)
        {
            int LastId = GetLastId();
            int Id = LastId+1;
            int RoomNo = Id;
            var CreatedRoom = RoomRepo.Create(Id, RoomType, RoomNo, Description);
            if (CreatedRoom != null)
            {
                Console.WriteLine($"Room {RoomNo} has been created successfully");

            }
            else
            {
                Console.WriteLine("Room creation was not successful");
            }


        }

        public List<Room> CreateManyRooms(string RoomType, string Description,int NoOfRooms)
        {
            List<Room> AddedRooms = new List<Room>();

            for(var r = 0; r <= NoOfRooms; r++)
            {
                int LastId = GetLastId();
              
                int Id = LastId+1;
              
                int RoomNo = Id;
                Room room = RoomRepo.Create(Id, RoomType, RoomNo, Description);
                AddedRooms.Add(room);

            }

            return AddedRooms;
        }


        public int GetLastId()
        {
            List<Room> rooms = RoomRepo.GetAll();
            if (rooms.Count !=0)
            {
                int index = rooms.Count - 1;
                return rooms[index].Id;
            }
            else
            {
                return 0;
            }
           
        }

        public void DisplayAllRooms()
        {
            var Rooms = RoomRepo.GetAll();

            foreach (var room in Rooms)
            {
                Console.WriteLine($"RoomNo:{room.RoomNo}\t Type:{room.RoomType}");
            }
        }

        public Room FindRoomByRoomNo(int RoomNo)
        {
            var FoundRoom = RoomRepo.FindByRoomNo(RoomNo);
            if (FoundRoom != null)
            {
                return FoundRoom;
            }
            return null;
        }


        public void EditRoom(int Id, int RoomNo, string RoomType, string Description)
        {
            var FoundRoom = FindRoomByRoomNo(RoomNo);

            if (FoundRoom != null)
            {
                var RoomUpdated = RoomRepo.update(FoundRoom, Id, RoomNo, RoomType, Description);
                if (RoomUpdated == true)
                {
                    Console.WriteLine($"Room {RoomNo} has been updated successfully");
                }
                else
                {
                    Console.WriteLine("Room Update not successful");
                }

            }
        }

        public void DeleteRoom(int RoomNo)
        {
            var FoundRoom = FindRoomByRoomNo(RoomNo);

           var DeletedRoom = RoomRepo.Delete(FoundRoom);
            if(DeletedRoom == true)
            {
                Console.WriteLine($"Room has {RoomNo} has been deleted");
            }
        }

    }
}
