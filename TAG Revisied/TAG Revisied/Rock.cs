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

        public override string UseOn(Item targetItem, GameState gameState)
        {
            switch (targetItem)
            {
                case Clock clock:
                    gameState.RemoveItemFromInventory(this);
                    clock.OnWall = false;
                    gameState.AddRoomItem(new Batteries());
                    return $"You throw the {Name} at the {clock.Name} knocking it to the floor!";

            }
            return base.UseOn(targetItem, gameState);
        }
    }
}
