using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied
{
    public class Mattress : Item
    {
        public bool IsCut;
        public Mattress() : base("MATTRESS", "Excised!", false) { IsCut = false; }
        public override string Inspect(GameState gameState)
        {
            if (!IsCut)
            {
                return $"The {Name} has a small stitched section on its side.";
            }
            return base.Inspect(gameState);
        }
        public override string Use(GameState gameState)
        {
            return "I'd rather sleep on the floor.";
        }
    }
}
