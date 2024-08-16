using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TAG_Revisied
{
    public class EngineRoomDoor : Item
    {
        public bool IsBlocked;
        public EngineRoomDoor() : base("DOOR", "You peek into the keyhole of the door, it's too dark for you to see.", false) { IsBlocked = true; }
        //UNCOMMENT THIS VVVVVVVV WHEN FLASHLIGHT.CS IS DEVELOPED
        //public override string Inspect(GameState gameState)
        //{
        //    var flashlight = gameState.GetItem("FLASHLIGHT") as Flashlight;
        //    return flashlight?.FlashlightInWall == true ? "You peek throught the keyhold and notice a shadow of an object stuck between the floor and the door handle." : Description;
        //}
        public override string Use(GameState gameState)
        {
            if (!IsBlocked)
            {
                return "The door is open already.";
            }
            return "The door is blocked from the other side.";
        }
    }
}
