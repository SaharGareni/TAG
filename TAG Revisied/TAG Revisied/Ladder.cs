using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied

{
    public class Ladder : Item
    {
        bool IsBroken = true;
        public Ladder() : base("LADDER","Dont walk under it.",true) { }
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
    }
}
