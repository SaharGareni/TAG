using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied

{
    public class SleepingQuarters : Room
    {

        public SleepingQuarters() : base("sleepingQuarters", "This room feels oddly quiet, save for the steady tick of something unseen. A BED and a CABINET sit idly in the shadows.") 
        {
            RoomItems.Add(new Cabinet());
			RoomItems.Add(new Clock());
			RoomItems.Add(new Bed());
			RoomItems.Add(new Pillow());
			RoomItems.Add(new Mattress());

		}
        public override string Inspect(GameState gameState)
        {
            Clock clock = gameState.GetItem("CLOCK") as Clock; 
            if (clock != null && !clock.HasBatteries)
            {
                return "At least the ticking is gone.";
            }
            return base.Inspect(gameState);
        }
        protected override string HandleNorth(GameState gameState)
        {
            return "A stale odor comes from a BED tucked a way in the corner.";
        }
        protected override string HandleEast(GameState gameState)
        {
            return "You see a rusty CABINET standing on the eastern wall.";
        }
        protected override string HandleSouth(GameState gameState)
        {
            return "As you turn SOUTH the ticking intensifies. Your eyes are drawn to the wall, where a CLOCK is mounted.";
        }
        protected override string HandleWest(GameState gameState)
        {
            return gameState.RoomManager.SetCurrentRoom("hallway");
        }
        protected override string GetFirstEntryMessage()
        {
            return "You head EAST and notice an entrance that’s mostly open. You decide to step inside the room.";
        }
    }
}
