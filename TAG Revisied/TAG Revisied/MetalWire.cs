using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied
{
    public class MetalWire : Item
    {
        public MetalWire() : base("METAL WIRE","Feels pliable...", true) { }

        public override string UseOn(Item targetItem,GameState gameState)
        {
            switch (targetItem)
            {
                case Door door:
                    gameState.Inventory.Remove(this);
                    door.IsLocked = false;
                    if (gameState.RoomManager.CurrentRoom is FirstRoom firstRoom)
                    {
                        firstRoom.FirstDoorLocked = false;
                    }
                    return "You bend the METAL WIRE to fit the lock in an attempt to pick it.\nYou successfully pick the lock!";


            }
            return "Nothing interesting happens.";
        }

    }
}
