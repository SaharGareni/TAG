using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied

{
    public class Door : Item
    {
        public bool IsLocked;
        public Door() : base("DOOR", "An ominous large metal door.",false) { IsLocked = true; }
        public override string Take(GameState gameState)
        {
            if (gameState.IsPlayerBound())
            {
                return "You are bound.";
            }
            return "\"You rip the DOOR from it's hinges and put it in your pocket\"...Now really?";
        }
        public override string Use(GameState gameState)
        {
            if (gameState.IsPlayerBound())
            {
                return "You are bound.";
            }
            return !IsLocked ? "The DOOR is unlocked." : "It's locked shut.";
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
