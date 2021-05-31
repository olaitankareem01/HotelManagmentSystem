using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagementSystem.Entities;

namespace HotelManagementSystem.Repository
{
    class RoomRepository
    {
        public List<Room> Rooms = new List<Room>();

        public List<Room> GetAll()
        {
            return Rooms;
        }
        public Room Create(int Id, string RoomType, int RoomNo, string Description)
        {
            Room room = new Room(Id, RoomType, RoomNo, Description);
            Rooms.Add(room);

            return room;
        }

    
        public bool update(Room room, int Id, int RoomNo, string RoomType, string Description)
        {
            var index = Rooms.FindIndex(room => room.RoomNo == RoomNo);
            if (index < 0)
            {
                return false;
            }

            Rooms[index] = new Room(Id, RoomType, RoomNo, Description);

            return true;

        }

        public Room FindByRoomNo(int RoomNo)
        {
            foreach(var room in Rooms)
            {
                if (room.RoomNo == RoomNo)
                {
                    return room;
                }
            }
            return null;
        }



        public bool Delete(Room room)
        {
            Rooms.Remove(room);
            return true;
        }
    }
}

