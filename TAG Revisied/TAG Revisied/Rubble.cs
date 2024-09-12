using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied

{
    public class Rubble : Item
    {
        public Rubble() : base("RUBBLE","Amidst the ROCKs and debris you make out a broken LADDER.",false) { }
        public override string Inspect(GameState gameState)
        {
            if (gameState.ContainsItem(gameState.RoomManager.CurrentRoom.RoomItems,"LADDER") && gameState.ContainsItem(gameState.RoomManager.CurrentRoom.RoomItems, "ROCK"))
            {
                return Description;
            }
            if (gameState.ContainsItem(gameState.RoomManager.CurrentRoom.RoomItems, "LADDER"))
            {
                return "A broken LADDER hides among the debris.";
            }
            return "Ruin is all that's left...";
        }

    }
}
