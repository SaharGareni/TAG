using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied
{
    public class Piston : Item
    {
        public Piston() : base("PISTON", "A tall metal shaft stands between the floor and ceiling, its outer layer appearing ready to move.", false) { }
        public override string Inspect(GameState gameState)
        {
            if ((gameState.GetItem("ENGINE") as Engine)?.IsOn ?? false)
            {
                return $"The outer layer of the {Name} slowly rises to the ceiling, then abruptly crashes to the ground.";
            }
            return base.Inspect(gameState);
        }
    }
}
