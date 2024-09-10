using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied
{
    public class EngineRoom : Room
    {
        public bool IsLitByFlashlight { get; set; }
        public bool IsEngineOn { get; set; }
        public bool IsRoomLit => IsLitByFlashlight || IsEngineOn;
        public EngineRoom() :base("engineRoom","engine room", "Upon examining the room you immediately notice an ENGINE" +
            "connected to a large PISTON." +
            "As you investigate further you notice a VENT in the NORTH WESTERN wall connected to a network of pipes.") { }
        public override string Inspect(GameState gameState)
        {
            if (!IsRoomLit)
            {
                return "The room is very dark. The light from the hallway barely lets you see your own hands.";
            }
            if (gameState.ContainsItem(RoomItems,"METAL BAR"))
            {
                return "Stepping into a shimmering puddle of gasoline, you notice the object that had obstructed the handle— " +
                    "a METAL BAR now lies discarded on the floor." +
                    "As your eyes scan the room, you uncover an ENGINE linked to a large PISTON." +
                    "Continuing your investigation, you spot a VENT in the northwestern wall, intricately connected to a network of pipes.";
            }
            return base.Inspect(gameState);
        }
        protected override string HandleNorth(GameState gameState)
        {
            if (!IsRoomLit)
            {
                return "You go NORTH, however its too dark for you to make out anything.";
            }
            return "You notice the opening for a VENT on the upper upper WESTERN corner of the wall.";
        }
        protected override string HandleEast(GameState gameState)
        {
            return gameState.RoomManager.SetCurrentRoom("hallway");
        }
        protected override string HandleSouth(GameState gameState)
        {
            if (!IsRoomLit)
            {
                return "You go SOUTH, however its too dark for you to make out anything.";
            }
            return "You notice the opening for a VENT on the upper WESTERN corner of the wall.";
        }
        protected override string HandleWest(GameState gameState)
        {
            if (!IsRoomLit)
            {
                return "You go WEST, however its too dark for you to make out anything.";
            }
            return "A large contraption of machinery reveals itself. An ENGINE of sorts linked to a massive PISTON.";
        }
    }
}
