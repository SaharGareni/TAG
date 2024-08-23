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
        public bool HasBatteries;
        public Clock() : base("CLOCK","Examining the CLOCK reveals slotted BATTERIES in it's back.",false) { OnWall = true; HasBatteries = true; }
        public override string Take(GameState gameState)
        {
            if (OnWall)
            {
                return "I can't reach that.";
            }
            return base.Take(gameState);
        }
        public override string Inspect(GameState gameState)
        {
            if (OnWall)
            {
                return "Right twice a day.";
            }
            if (!HasBatteries)
            {
                return "Finally. The ticking is gone";
            }
            return base.Inspect(gameState);
        }

    }
}
