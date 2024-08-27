using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied

{
    public class Bed : Item
    {
        public Bed() : base("BED","The furniture for sleeping! MATTRESS and PILLOW are included.",false) { }
        public override string Use(GameState gameState)
        {
            return "\"You may not rest now, there are monsters nearby.\"";
        }
    }
}
