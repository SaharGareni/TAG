using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied

{
    public class Cabinet : Item
    {
        public bool IsLocked;
        public bool IsClosed;
        public Cabinet() : base("CABINET","A long metallic box used to contain things.",false) { IsClosed = true; IsLocked = true; }
        public override string Inspect(GameState gameState)
        {
            if (IsLocked)
            {
                return $"A tiny keyhole is subtly integrated into one of the {Name}'s handles.";
            }
            if (IsClosed)
            {
                return $"The {Name} is closed.";
            }
            if (!IsClosed)
            {
                if (gameState.ContainsItem(gameState.RoomManager.CurrentRoom.RoomItems,"GAS CAN") && gameState.ContainsItem(gameState.RoomManager.CurrentRoom.RoomItems, "FLASHLIGHT"))
                {
                    return $"You look inside the {Name} and see a GAS CAN and a FLASHLIGHT.";
                }
                else if (gameState.ContainsItem(gameState.RoomManager.CurrentRoom.RoomItems, "GAS CAN"))
                {
                   return $"You look inside the {Name} and see a GAS CAN.";
                }
                else if (gameState.ContainsItem(gameState.RoomManager.CurrentRoom.RoomItems, "FLASHLIGHT"))
                {
                    return $"You look inside the {Name} and see a FLASHLIGHT.";
                }
            }
            return base.Inspect(gameState);
        }
        public override string Use(GameState gameState)
        {
            if (IsLocked)
            {
                return "It's locked. How surprising...";
            }
            if (IsClosed)
            {
                IsClosed = false;
                gameState.RoomManager.CurrentRoom.RoomItems.Add(new GasCan());
                gameState.RoomManager.CurrentRoom.RoomItems.Add(new Flashlight());
                return "You open the CABINET.";
            }
            return "It's already open.";
        }
    }
}
