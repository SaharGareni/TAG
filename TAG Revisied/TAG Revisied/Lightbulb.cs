using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied
{
    public class Lightbulb : Item
    {
        public Lightbulb() : base("LIGHTBULB","A fragile piece of glass made for illumination.",false) { }

        public override string Inspect(GameState gameState)
        {
            if (gameState.IsPlayerBound())
            {
                return "You are bound.";
            }
            return Description;
        }
        public override string Take(GameState gameState)
        {
            if (gameState.IsPlayerBound())
            {
                return "You are bound.";
            }
            return "It's too high for me to reach.";
        }
        public override string Use(GameState gameState)
        {
            if (gameState.IsPlayerBound())
            {
                return "You are bound.";
            }
            return "Nothing intresting happens.";
        }
        public override string UseOn(Item targetItem,GameState gameState)
        {
            switch (targetItem)
            {
                case Wall wall:
                    gameState.Inventory.Add(new GlassShard());
                    gameState.Inventory.Add(new BrokenLightbulb());
                    gameState.ConditionalItems.Add(new MetalWire());
                    gameState.Inventory.Remove(this);
                    return $"You smash the {Name} against the WALL obtaining a BROKEN LIGHTBULB and a GLASS SHARD in the process.";
            }
            return "Nothing interesting happens.";
        }
    }
}
