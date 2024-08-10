﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied
{
    public class Hallway : Room
    {
        public bool engineRoomBlocked;
        public Hallway() : base("hallway", "A damp corridor stretches before you, with a door to the right and another to the left. Up ahead, the path is choked with RUBBLE, blocking your way.") { engineRoomBlocked = true; }
        public override string Go(string target, GameState gameState)
        {
            switch (target)
            {
                case "NORTH":
                    return $"You venture further {target} into the {Name} where a pile of RUBBLE stops you in your tracks.";
                case "EAST":
                    gameState.RoomManager.SetCurrentRoom("sleepingQuarters");
                    return $"You head {target} and notice an entrance that’s mostly open. You decide to step inside the room.";
                case "SOUTH":
                    gameState.RoomManager.SetCurrentRoom("firstRoom");
                    return "You go back to the room which you woke up in.";
                case "WEST":
                    if (engineRoomBlocked)
                    {
                        return "You attempt to open the door on your left. It wont budge.";
                    }
                    gameState.RoomManager.SetCurrentRoom("engineRoom");
                    return "You step into the room. The eerie buzz of the flickering fluorescent light breaks the stillness.";
            }
            return "I can't go there.";
        }
    }
}
