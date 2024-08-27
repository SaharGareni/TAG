using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied

{
    public class GlassShard : Item
    {
        public GlassShard() : base("GLASS SHARD", "Ouch! Definitely sharp as advertised...", true) { }
        public override string Use(GameState gameState)
        {
            return "Nothing interesting happens.";
        }
        public override string UseOn(Item targetItem,GameState gameState)
        {
            switch (targetItem)
            {
                case Mattress mattress:
                    mattress.IsCut = true;
                    gameState.AddRoomItem(new SmallKey());
                    gameState.RemoveItemFromInventory(this);
                    return $"You cut the stitched portion of the {mattress.Name} and find a SMALL KEY hidden inside!, but break the {Name} in the process.";
            }
            return "Nothing interesting happens.";
        }
    }
}
