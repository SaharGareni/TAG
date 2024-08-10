using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied
{
    public class Rope : Item
    {
        public Rope() : base("ROPE", "The ties that bind.",true) { }

        public override string Take(GameState gameState)
        {
            if (gameState.IsPlayerBound())
            {
                return "You are bound.";
            }
            return base.Take(gameState);
        }
        public override string Use(GameState gameState)
        {
            if (gameState.IsPlayerBound())
            {
                return "You are bound.";
            }
            return "Nothing interesting happens.";
        }

        public override string UseOn(Item targetItem,GameState gameState)
        {
            if (gameState.IsPlayerBound())
            {
                return "You are bound.";
            }
            //switch (targetItem.Name)
            //{
            //    case "lever":
            //        return "You attach the rope to the lever";
            //}
            return "Nothing interesting happens.";
        }
    }


}
