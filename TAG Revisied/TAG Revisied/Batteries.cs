using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied
{
    public class Batteries : Item
    {
        public enum BatteriesState
        {
            InClock,
            InFlashlight,
            InInventory
        }
        public BatteriesState State;
        public Batteries() : base("BATTERIES","Small capsules of power.",true) { State = BatteriesState.InClock; }
        public override string Take(GameState gameState)
        {
            if (State == BatteriesState.InClock)
            {
                State = BatteriesState.InInventory;
                return $"You take the {Name} out of the CLOCK. " + base.Take(gameState);
            }
            if (State == BatteriesState.InFlashlight)
            {               
                Flashlight  flashlight = gameState.GetItem("FLASHLIGHT") as Flashlight;
                State = BatteriesState.InInventory;
                if (flashlight.State == Flashlight.FlashlightState.Loaded)
                {
                    flashlight.IsOn = false;
                    flashlight.State = Flashlight.FlashlightState.Empty;
                }
                else if (flashlight.State == Flashlight.FlashlightState.InCrackLoaded)
                {
                    flashlight.IsOn = false;
                    flashlight.State = Flashlight.FlashlightState.InCrackEmpty;
                }
                return $"You take the {Name} out of the FLASHLIGHT. " + base.Take(gameState);
            }
            return base.Take(gameState);
        }
        public override string Inspect(GameState gameState)
        {
            if (State == BatteriesState.InFlashlight)
            {
                return $"The {Name} are placed in the FLASHLIGHT.";
            }
            return base.Inspect(gameState);
        }
        //unfinished taking a break
        //need to figure out a smart way for UseOn taking out and slotting in the battries with the given inventory system.
        public override string UseOn(Item targetItem, GameState gameState)
        {
            if (!(State == BatteriesState.InInventory))
            {
                return "I'd need to have them first.";
            }
            switch (targetItem)
            {
                case Flashlight flashlight:
                    gameState.AddConditionalItem(this);
                    gameState.RemoveItemFromInventory(this);
                    flashlight.State = Flashlight.FlashlightState.Loaded;
                    State = BatteriesState.InFlashlight;
                    return $"You place the {Name} in the {flashlight.Name}.";
                    
            }
            return base.UseOn(targetItem, gameState);
        }
    }
}
