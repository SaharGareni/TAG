namespace TAG_Revisied
{
    public class Flashlight : Item
    {
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
        public override string Inspect(GameState gameState)
        {
            if (State == FlashlightState.Empty || State == FlashlightState.InCrackEmpty)
            {
                return "Looks to be missing some BATTERIES.";
            }
            if (State == FlashlightState.Loaded || State == FlashlightState.InCrackLoaded)
            {
                return $"The {Name} is off, no light is coming out.";
            }
            return base.Inspect(gameState);
        }
        public override string Use(GameState gameState)
        {
            if (State == FlashlightState.Empty || State == FlashlightState.InCrackEmpty)
            {
                return $"The {Name} remains dark.";
            }
            if (!IsOn)
            {
                IsOn = !IsOn;
                return $"You turn on the {Name}.";
            }
            else
            {
                IsOn = !IsOn;
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
