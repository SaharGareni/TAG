using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied
{
    public class MetalBar : Item
    {
        public MetalBar() : base("METAL BAR","Out of place...",true) { }
        public override string UseOn(Item targetItem, GameState gameState)
        {
            switch (targetItem)
            {
                case Ladder ladder :
                    ladder.IsBroken = false;
                    gameState.RemoveItemFromInventory(this);
                    return $"The {Name} slots perfectly into the the {ladder.Name}!";
            }
            return base.UseOn(targetItem, gameState);
        }
    }
}
