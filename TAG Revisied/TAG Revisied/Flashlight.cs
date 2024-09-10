namespace TAG_Revisied

{
    public class Flashlight : Item
    {
        //this some work here is needed
        //the 4 way interaction between this, batteries, crack and engine room
        //is unfinished and janky.
        //need to make sure every case is accounted for.
        public bool IsOn;
        public enum FlashlightState
        {
            Empty,
            Loaded,
            InCrackEmpty,
            InCrackLoaded,
        }
        public FlashlightState State;
        public Flashlight() : base("FLASHLIGHT", "A steady light comes from the FLASHLIGHT.", true) { IsOn = false; State = FlashlightState.Empty; }
        public override string Take(GameState gameState)
        {
            if (State == FlashlightState.InCrackLoaded)
            {
                var engineRoom = gameState.RoomManager.GetRoom("engineRoom") as EngineRoom;
                engineRoom.IsLitByFlashlight = false;
                State = FlashlightState.Loaded;
                return base.Take(gameState);
            }
            else if (State == FlashlightState.InCrackEmpty)
            {
                var engineRoom = gameState.RoomManager.GetRoom("engineRoom") as EngineRoom;
                engineRoom.IsLitByFlashlight = false;
                State = FlashlightState.Empty;
                return base.Take(gameState);
            }
            return base.Take(gameState);
        }
        public override string Inspect(GameState gameState)
        {
            if (State == FlashlightState.Empty || State == FlashlightState.InCrackEmpty)
            {
                return "Looks to be missing some BATTERIES.";
            }
            if (!IsOn)
            {
                return $"The {Name} is off, no light is coming out.";
            }
            return base.Inspect(gameState);
        }
        public override string Use(GameState gameState)
        {
            // Check if flashlight is missing batteries
            if (State == FlashlightState.Empty || State == FlashlightState.InCrackEmpty)
            {
                return $"The {Name} remains dark. It looks like it's missing a power source.";
            }

            // Handle turning the flashlight on/off based on state
            var engineRoom = gameState.RoomManager.GetRoom("engineRoom") as EngineRoom;

            if (State == FlashlightState.InCrackLoaded)
            {
                // Handle the engine room lighting
                if (!IsOn)
                {
                    engineRoom.IsLitByFlashlight = true;
                    IsOn = true;
                    return $"You turn on the {Name}. It lights up the room.";
                }
                else
                {
                    engineRoom.IsLitByFlashlight = false;
                    IsOn = false;
                    return $"You turn off the {Name}. The room goes dark.";
                }
            }

            // For all other Loaded states (not in crack)
            IsOn = !IsOn;
            if (IsOn)
            {                
                engineRoom.IsLitByFlashlight = true;
                return $"You turn on the {Name}.";
            }
            else
            {
                engineRoom.IsLitByFlashlight = false;
                return $"You turn off the {Name}.";
            }
        }
        public override string UseOn(Item targetItem, GameState gameState)
        {
            switch (targetItem)
            {
                case Crack crack:
                    if (State == FlashlightState.InCrackEmpty || State == FlashlightState.InCrackLoaded)
                    {
                        return $"It's already placed in the {crack.Name}.";
                    }
                    gameState.RoomManager.CurrentRoom.RoomItems.Add(this);
                    gameState.Inventory.Remove(this);
                    if (State == FlashlightState.Loaded)
                    {
                        State = FlashlightState.InCrackLoaded;
                        gameState.MoveConditionalItem("BATTERIES", gameState.RoomManager.CurrentRoom.RoomItems);
                    }
                    else
                    {
                        State = FlashlightState.InCrackEmpty;
                    }
                    return $"You place the {Name} in the {crack.Name} of the wall.";
            }
            return base.UseOn(targetItem, gameState);
        }
    }
}
