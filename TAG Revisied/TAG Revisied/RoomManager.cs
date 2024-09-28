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
            var sleepingQuarters = new SleepingQuarters();
            var engineRoom = new EngineRoom();
            AddRoom(room);
            AddRoom(hallway);
            AddRoom(sleepingQuarters);
            AddRoom(engineRoom);
            //will probably have to isntatiate every room here instead of game initializer 
            //then store them in the dictionary
        }
        //IMPORTANT: BOTH ADDROOM AND SETCURRENTROOM TAKE THE 
        //NAME STRING OF THE ROMM AND ToLower()s THEM
        //SO THE INPUT WHEN CALL THE METHOD ISNT SENSITVE FOR NOW
        public void AddRoom(Room room)
        {
            if (!_rooms.ContainsKey(room.Name))
            {
                _rooms[room.Name.ToLower()] = room;
            }
        }
        public  string SetCurrentRoom(string roomName)
        {
            CurrentRoom = GetRoom(roomName);
            return CurrentRoom.Enter();
        }
        public Room GetRoom(string roomName)
        {
            if (_rooms.TryGetValue(roomName.ToLower(), out Room room))
            {
                return room;
            }
            else throw new Exception("This room does not exist yet. RoomManager.GetRoom()  LN 49");
        }
        public void ExitCurrnetRoom()
        {
            CurrentRoom?.Exit();
        }
    }
}
