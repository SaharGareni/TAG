using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied
{
    public class Crack : Item
    {
        public Crack() : base("CRACK","Someone must've gotten real mad...",false){ }
        public override string Use(GameState gameState)
        {
            if (gameState.ContainsItem(gameState.RoomManager.CurrentRoom.RoomItems, "FLASHLIGHT"))
            {
                return $"The FLASHLIGHT uses the {Name} now.";
            }
            return "You look into the CRACK, but see only darkness.";
        }
    }
}
