using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied
{
    internal class Window : Item
    {
        public Window() : base("WINDOW", "A hole to the outside world, just barely out of reach...",false) { }
        public override string Take(GameState gameState)
        {
            if (gameState.IsPlayerBound())
            {
                return "You are bound.";
            }
            return "Now how exactly are you going to take the window?";
        }
        public override string Inspect(GameState gameState)
        {
            if (gameState.IsPlayerBound())
            {
                return "You are bound.";
            }
            return Description;
        }
        public override string Use(GameState gameState)
        {
            if (gameState.IsPlayerBound())
            {
                return "You are bound.";
            }
            return "It's too high for you to reach.";
        }
        public override string UseOn(Item targetItem, GameState gameState)
        {
            if (gameState.IsPlayerBound())
            {
                return "You are bound.";
            }
            return base.UseOn(targetItem, gameState);
        }
    }
}
