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
        public bool FloorWithGas;
        public EngineRoomDoor() : base("DOOR", "You peek into the keyhole of the door, it's too dark for you to see.", false) { IsBlocked = true; FloorWithGas = false; }
        public override string Inspect(GameState gameState)
        {
            var flashlight = gameState.GetItem("FLASHLIGHT") as Flashlight;
            return (flashlight?.State == Flashlight.FlashlightState.InCrackLoaded && flashlight.IsOn) ? "You peek throught the keyhole and notice a shadow of an object stuck between the floor and the door handle." : Description;
        }
        public override string Use(GameState gameState)
        {
            if (!IsBlocked)
            {
                return $"The {Name} is open already.";
            }
            if (FloorWithGas)
            {
                IsBlocked = false;
                gameState.RoomManager.SetCurrentRoom("engineRoom");
                return $"You forcefully ram against the {Name}." +
                    $"A loud bang echoes as something metallic drops to the floor, freeing the handle." +
                    $"With the obstacle removed, you barge into the room.";
            }
            return $"The {Name} is blocked from the other side.";
        }
    }
}
