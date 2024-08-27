using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied

{
    public class GasCan : Item
    {
        public GasCan() : base("GAS CAN","It's filled with gasoline.",true) { }
        public override string UseOn(Item targetItem, GameState gameState)
        {
            if (targetItem is EngineRoomDoor engineRoomDoor)
            {
                engineRoomDoor.FloorWithGas = true;
                return "You pour some gasoline through the keyhold of the DOOR.";
            }
            else if (targetItem is Flashlight flashlight)
            {
                return "It doesn't use this kind of fuel.";
            }
            return base.UseOn(targetItem, gameState);
        }
    }
}
