using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied
{
    public class Rock : Item
    {
        public Rock() : base("ROCK","And a hard place.",true) { }

        //UNCOMMENT THIS VVVVVVVV WHEN CLOCK.CS IS DEVELOPED
        //public override string UseOn(Item targetItem, GameState gameState)
        //{
        //    switch (targetItem)
        //    {
        //        case Clock clock:
        //            gameState.RemoveItemFromInventory(this);
        //            clock.IsObtainable = true;
        //            return $"You throw the {Name} at the {clock.Name} knocking it to the floor!";
        //    }
        //    return base.UseOn(targetItem, gameState);
        //}
    }
}
