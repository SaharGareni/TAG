using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied

{
    public class Hallway : Room
    {
        public bool engineRoomBlocked;
        public Hallway() : base("hallway","hallway", "A damp corridor stretches before you, with a DOOR to the left and another to the right." +
            "Up ahead, the path is choked with RUBBLE, blocking your way." +
            "To the WEST you notice a CRACK in the wall next to the DOOR, big enough to almost fit your hand in.") 
        { 
            engineRoomBlocked = true;
            RoomItems.Add(new Rubble());
			RoomItems.Add(new Ladder());
			RoomItems.Add(new Rock());
			RoomItems.Add(new Crack());
			RoomItems.Add(new EngineRoomDoor());
		}
        public override string Go(string target, GameState gameState)
        {
            switch (target)
            {
                case "NORTH":
                    return $"You venture further {target} into the {Name} where a pile of RUBBLE stops you in your tracks.";
                case "EAST":
                    return gameState.RoomManager.SetCurrentRoom("sleepingQuarters");
                case "SOUTH":
                    return gameState.RoomManager.SetCurrentRoom("firstRoom");
                case "WEST":
                    if (engineRoomBlocked)
                    {
                        return "You attempt to open the DOOR on your left. It won't budge.";
                    }
                    return gameState.RoomManager.SetCurrentRoom("engineRoom");
                    //The eerie buzz of the flickering fluorescent light breaks the stillness.";
            }
            return "I can't go there.";
        }
        protected override string GetFirstEntryMessage()
        {
            return "You step through the door into a dimly lit hallway. " +
                "As you enter, an echoing rumble comes from your right, sending shivers down your spine." +
                "You notice two entrances from either side, the doorway to your right seems to be half opened.";
        }
    }
}
