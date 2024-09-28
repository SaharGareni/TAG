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
            switch (targetItem)
            {
                case EngineRoomDoor engineRoomDoor:
                    engineRoomDoor.FloorWithGas = true;
                    return "You pour some gasoline through the keyhole of the DOOR.";
                case Flashlight flashlight:
                    return "It doesn't use this kind of fuel.";
                case Engine engine:
                    engine.IsFueled = true;
                    //dont have to remove it here lore wise just doing for now cuz its safer
                    gameState.RemoveItemFromInventory(this);
                    return $"You fill the {engine.Name} with gasoline and discard the now empty {Name}.";

            }
            return base.UseOn(targetItem, gameState);
        }
    }
}
