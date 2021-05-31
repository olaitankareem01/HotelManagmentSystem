using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomType { get; set; }
        public int RoomNo { get; set; }
        public string Description { get; set; }

        
        public Room()
        {

        }
        public Room(int Id,string RoomType,int RoomNo,string Description)
        {
            this.Id = Id;
            this.RoomType = RoomType;
            this.RoomNo = RoomNo;
            this.Description = Description;
        }
    }
}
