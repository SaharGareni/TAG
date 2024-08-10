using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied
{
    public class GlassShard : Item
    {
        public GlassShard() : base("GLASS SHARD", "Ouch! Defenitly sharp as advertised...", true) { }
        public override string Use(GameState gameState)
        {
            return "Nothing interesting happens.";
        }
        public override string UseOn(Item targetItem,GameState gameState)
        {
            switch (targetItem)
            {
                case Rope:
                    return "A good idea! Just not for now.";
            }
            return "Nothing interesting happens.";
        }
    }
}
