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
        public Cabinet() : base("CABINET","A long metalic box used to contain things.",false) { IsClosed = true; IsLocked = true; }
        public override string Inspect(GameState gameState)
        {
            if (IsLocked)
            {
                return $"A tiny keyhole is subtly integrated into one of the {Name}'s handles.";
            }
            if (!IsClosed)
            {
                //if (room contians both gas tank(?) and the flashlight) {return "you look inside the cabinet and see a gas tank and a flashlight }
                //else if (room only contains gas tank) {you look inside the cabinet and see a gas tank }
                //else if (room only contains flashlight) {you look inside the cabinet and see a flashlight}
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
