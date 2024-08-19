using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied
{
    public class Clock : Item
    {
        public bool OnWall;
        public Clock() : base("CLOCK","Examining the CLOCK reveals slotted BATTERIES in it's back.",false) { OnWall = true; }
        public override string Inspect(GameState gameState)
        {
            if (OnWall)
            {
                return "Right twice a day.";
            }
            return base.Inspect(gameState);
        }
    }
}
