using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied
{
    public class Wall : Item
    {
        public Wall() : base("WALL", "A solid facade of concrete." , false) { }
        public override string Take(GameState gameState)
        {
            if (gameState.IsPlayerBound())
            {
                return "You are bound.";
            }
            return "It would require immense strength...";
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
            return "Nothing of use on the WALL.";
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
