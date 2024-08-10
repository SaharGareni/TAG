using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied
{
    public class Chair : Item
    {
        public Chair() : base("CHAIR", "At least they gave you something to sit on...", false) { }

        public override string Take(GameState gameState)
        {
            if (gameState.IsPlayerBound())
            {
                return "You are bound.";
            }
            return "I think I'll leave it there.";
        }
        public override string Use(GameState gameState)
        {
            return "Now is not the time for sitting idly.";
        }

        public override string UseOn(Item targetItem, GameState gameState)
        {
            if (gameState.IsPlayerBound())
            {
                return "You are bound.";
            }
            switch (targetItem)
            {
                case Lightbulb lightbulb :
                    if (gameState.Inventory.Contains(lightbulb))
                    {
                        return "I already have that.";
                    }
                    gameState.TakeItemFromSource(lightbulb,gameState.RoomManager.CurrentRoom.RoomItems);
                    return "You use the CHAIR to reach the LIGHTBULB. You unscrew the LIGHTBULB, obtaining it in the process.";
                case Window window :
                    return "You use the CHAIR to reach the WINDOW. Although it is mostly boarded you catch a glimpse of a shadow barely moving out of sight, as if it was looking towards you.";


            }
            return base.UseOn(targetItem, gameState);
        }
    }
}
