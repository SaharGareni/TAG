using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied

{
    public class Ladder : Item
    {
        public bool IsBroken {  get; set; }
        public Ladder() : base("LADDER","Don't walk under it.",true) { IsBroken = true; }
        public override string Take(GameState gameState)
        {
            if (IsBroken)
            {
                return "It's no use to me in this state";
            }
            return base.Take(gameState);
        }
        public override string Inspect(GameState gameState)
        {
            if (IsBroken)
            {
                return "Looks like it's missing a step. Literally.";
            }
            return base.Inspect(gameState);
        }
        //VVVV CREATE THE USE AND THE USEON FUNCTIONS WHEN ENGINEROOM IS DEVELOPED VVVV
        public override string UseOn(Item targetItem, GameState gameState)
        {
            switch (targetItem)
            {
                case Vent vent:
                    gameState.AddRoomItem(this);
                    gameState.RemoveItemFromInventory(this);
                    return $"You lean the {Name} against the wall to reach the {vent.Name}";
            }
            return base.UseOn(targetItem, gameState);
        }
    }
}
