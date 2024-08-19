using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied
{
    public class SmallKey : Item
    {
        public SmallKey() : base("SMALL KEY","A SMALL KEY for a small lock.",true) { }

        public override string UseOn(Item targetItem, GameState gameState)
        {
            if (targetItem is Cabinet cabinet)
            {
                gameState.RemoveItemFromInventory(this);
                cabinet.IsLocked = false;
                return $"You unlock the {cabinet.Name}.";
            }
            return base.UseOn(targetItem, gameState);
        }

    }
}
