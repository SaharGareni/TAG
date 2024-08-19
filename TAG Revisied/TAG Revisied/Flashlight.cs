using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied
{
    public class Flashlight : Item
    {
        public bool IsOn;
        public bool HasBatteries;
        public Flashlight() : base("FLASHLIGHT", "A steady light comes from the FLASHLIGHT.", true) { IsOn = false; HasBatteries = false;}
        public override string Inspect(GameState gameState)
        {
            if (!HasBatteries)
            {
                return "Looks to be missing some BATTERIES";
            }
            if (!IsOn)
            {
                return $"The {Name} is off, no light is coming out.";
            }
            return base.Inspect(gameState);
        }
        public override string Use(GameState gameState)
        {
           if (!HasBatteries)
           {
                return $"The {Name} remains dark.";
           }
           if (!IsOn)
           {
                IsOn = true;
                return $"You turn on the {Name}.";
           }
           else
           {
                return $"You turn off the {Name}.";
           }
        }
        public override string UseOn(Item targetItem, GameState gameState)
        {
            if (targetItem is Crack crack)
            {
                gameState.RoomManager.CurrentRoom.RoomItems.Add(this);
                gameState.Inventory.Remove(this);
                return $"You place the {Name} in the {crack.Name} of the wall.";
            }
            return base.UseOn(targetItem, gameState);
        }
    }
}
