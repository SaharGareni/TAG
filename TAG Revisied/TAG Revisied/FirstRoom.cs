using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied
{
    public class FirstRoom : Room
    {
        public bool FirstDoorLocked { get; set; }
        public int IsBoundCount { get;  set; }
        public FirstRoom() : base("firstRoom", "An almost desolate room, encased by cold concrete WALLS. An object clings to the WALL on the left, while dim light seeps in from your right, casting eerie shadows. Above, something ominously dangles from the ceiling.")
        {
            FirstDoorLocked = true;
            IsBoundCount = 0;
            RoomItems.Add(new Rope());
            RoomItems.Add(new Wall());
            RoomItems.Add(new Chair());
            RoomItems.Add(new Lightbulb());
            RoomItems.Add(new Door());
            RoomItems.Add(new Switch());
            RoomItems.Add(new Window());
        }
        public override void Enter()
        {

        }
        public override void Exit() { }
        //Go function currenrtly has unimplemeted interaction with the the door since the item Door and this class's boolean have no way
        //to communicate with eachother currently
        public override string  Go(string target, GameState gameState)
        {
            if (IsBoundCount < 3 && (target == "EAST" || target == "WEST" || target == "NORTH" || target == "SOUTH"))
            {
                switch (IsBoundCount)
                {
                    case 0:
                        IsBoundCount++;
                        return $"You swing to the {target}, the CHAIR budges.";
                    case 1:
                        IsBoundCount++;
                        return $"You violently swing to the {target} and cause the CHAIR to fall over, loosening the bind in the proccess.";
                    case 2:
                        IsBoundCount++;
                        return "You successfully slip away from the ROPE that binded you to the CHAIR.";
                }
            }
            ////OLD ITERATION OF CODE ABOVE - CHECK IF WORKS FIRST
            //if (IsBoundCount < 1 && (target == "EAST" || target == "WEST" || target == "NORTH" || target == "SOUTH")) //when chair bound
            //{

            //    IsBoundCount++;
            //    return $"You swing to the {target}, the CHAIR budges.";
            //}
            //else if (IsBoundCount < 2 && (target == "EAST" || target == "WEST" || target == "NORTH" || target == "SOUTH"))
            //{
            //    IsBoundCount++;
            //    return $"You violently swing to the {target} and cause the CHAIR to fall over, loosening the bind in the proccess.";
            //}
            //else if (IsBoundCount < 3 && (target == "EAST" || target == "WEST" || target == "NORTH" || target == "SOUTH"))
            //{
            //    IsBoundCount++;
            //    return "You successfully slip away from the ROPE that binded you to the CHAIR.";
            //}
            switch (target) //when free from chair
            {
                case "NORTH":
                    if (!FirstDoorLocked)
                    {
                        gameState.RoomManager.SetCurrentRoom("hallway");
                        return "You step through the door into a dimly lit hallway. As you enter, an echoing rumble comes from your right, sending shivers down your spine.\nYou notice two entrances from either side, the doorway to your right seems to be half opened.";
                    }
                    return $"You go to the {target}, there is a heavy metal DOOR blocking your way.";
                case "EAST":
                    return $"You go to the {target}, there is a WINDOW on the WALL, just out of reach.";
                case "SOUTH":
                    return $"You go to the {target}, Staring at you is a cold concrete WALL.";
                case "WEST":
                    return $"You go to the {target}, Feeling your hands against the WALL you make out a SWITCH.";
                case "DOOR":
                    if (IsBoundCount < 3)
                    {
                        return "You are bound.";
                    }
                    if (FirstDoorLocked)
                    {
                        return "You attemp going through the DOOR. It is locked shut.";
                    }
                    gameState.RoomManager.SetCurrentRoom("hallway");
                    return "You step through the door into a dimly lit hallway. As you enter, an echoing rumble comes from your right, sending shivers down your spine.\nYou notice two entrances from either side, the doorway to your right seems to be half opened.";

            }
             return "I can't go there.";
        }
        //VV need to edit this function to acutlaly interact with the door
        public void UnlockFirstDoor()
        {
            FirstDoorLocked = true;
        }

    }
}
