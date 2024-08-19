using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied
{
    public class Batteries : Item
    {
        public bool InClock;
        public bool InFlashlight;
        public Batteries() : base("BATTERIES","Power at your fingertips!",true) { InClock = true; InFlashlight = false; }
        public override string Take(GameState gameState)
        {
            if (InClock)
            {
                return $"You unslot the {Name} out of the CLOCK. " + base.Take(gameState);
            }
            if (InFlashlight)
            {
                return $"You unslot the {Name} out of the FLASHLIGHT. " + base.Take(gameState);
            }
            return base.Take(gameState);
        }
        //unfinished taking a break
        //need to figure out a smart way for UseOn taking out and slotting in the battries with the given inventory system.
    }
}
