using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied
{
    public class RoomManager
    {
        private readonly Dictionary<string, Room> _rooms;
        public Room CurrentRoom { get; private set; }

        public RoomManager(Room room)
        {
            //this dicitonary stores all the rooms in the game for potential future use
            _rooms = new Dictionary<string, Room>();
            CurrentRoom = room;
            var hallway = new Hallway();
            AddRoom(room);
            AddRoom(hallway);
            //will probably have to isntatiate every room here instead of game initializer 
            //then store them in the dictionary
        }
        public void AddRoom(Room room)
        {
            if (!_rooms.ContainsKey(room.Name))
            {
                _rooms[room.Name.ToLower()] = room;
            }
        }
        public void SetCurrentRoom(string roomName)
        {
            if (_rooms.TryGetValue(roomName, out Room room))
            {
                CurrentRoom = room;
                room.Enter();
            }
            else
            {
                Console.WriteLine("COULD NOT SET THE ROOM INVLALID ROOM NAME");
            }
        }
        public void ExitCurrnetRoom()
        {
            CurrentRoom?.Exit();
        }
    }
}
