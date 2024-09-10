using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied

{
    public class Rope : Item
    {
        public bool TiedToVent { get; set; }
        public bool TiedToPiston { get; set; } 
        public bool TiedToPistonAndVent =>  TiedToPiston && TiedToVent;
        public Rope() : base("ROPE", "The ties that bind.",true) { }
        public override string Inspect(GameState gameState)
        {
            if (TiedToPistonAndVent)
            {
                return $"The {Name} is attached to the PISTON and the VENT cover, pulling it taut.";
            }
            if (TiedToPiston)
            {
                return $"The {Name} is fastened to the PISTON.";
            }
            if (TiedToVent)
            {
                return $"The {Name} is bound to the VENT cover.";
            }
            return base.Inspect(gameState);
        }

        public override string Take(GameState gameState)
        {
            if (gameState.IsPlayerBound())
            {
                return "You are bound.";
            }
            if (TiedToPiston || TiedToVent)
            {
                TiedToPiston = false;
                TiedToVent = false;
            }
            return base.Take(gameState);
        }
        public override string Use(GameState gameState)
        {
            if (gameState.IsPlayerBound())
            {
                return "You are bound.";
            }
            return "Nothing interesting happens.";
        }

        public override string UseOn(Item targetItem,GameState gameState)
        {
            if (gameState.IsPlayerBound())
            {
                return "You are bound.";
            }
            switch (targetItem)
            {
                case Vent vent:
                    if (gameState.ContainsItem(gameState.RoomManager.CurrentRoom.RoomItems, "LADDER"))
                    {
                        if (TiedToVent)
                        {
                            return $"It's already tied to the {vent.Name}";
                        }
                        else if (TiedToPiston)
                        {
                            if ((gameState.GetItem("ENGINE") as Engine )?.IsOn ?? false)
                            {
                                vent.IsCovered = false;
                                gameState.RemoveRoomItem(this);
                                return $"You tie the other end of the {Name} to the cover of the {vent.Name}. The {Name} is stretched thin." +
                                    "The PISTON seems to to be struggling to rise..." +
                                    $"As the piston forcefully descends it rips the cover which blocked the {vent.Name}.";
                            }
                        }
                        TiedToVent = true;
                        gameState.AddRoomItem(this);
                        gameState.RemoveItemFromInventory(this);
                        return $"You tie one end of the {Name} to the cover of the {vent.Name}.";
                    }
                    return $"I can't reach {vent.Name}";
                case Piston piston:
                    if (TiedToPiston)
                    {
                        return $"It's already tied to the {piston.Name}";
                    }
                    else if (TiedToVent)
                    {
                        if ((gameState.GetItem("ENGINE") as Engine)?.IsOn ?? false)
                        {
                            var vent = gameState.GetItem("VENT") as Vent;
                            vent.IsCovered = false;
                            gameState.RemoveRoomItem(this);
                            return $"You tie the other end of the {Name} to the cover of the {piston.Name}. The {Name} is stretched thin." +
                                $"The {piston.Name} seems to to be struggling to rise..." +
                                $"As the piston forcefully descends it rips the cover which blocked the {vent.Name}.";
                        }
                    }
                    TiedToPiston = true;
                    gameState.AddRoomItem(this);
                    gameState.RemoveItemFromInventory(this);
                    return $"You tie one end of the {Name} to the cover of the {piston.Name}.";
            }
            //USED FOR TESTING IGNORE THAT
            //switch (targetItem.Name)
            //{
            //    case "ROCK":
            //        targetItem.Inspect(gameState);
            //        return "You attach the rope to the lever";
            //}
            return "Nothing interesting happens.";
        }
    }


}
