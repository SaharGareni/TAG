using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied
{
    public class Vent : Item
    {
        public bool IsCovered { get; set; }
        public Vent() : base("VENT","An opening to a covered VENT shaft is located at the top of the NORTH-WESTERN wall's corner.",false) { IsCovered = true; }
        public override string Inspect(GameState gameState)
        {
            return IsCovered ? Description : $"The {Name} cover no longer blocks your way.";
        }
        public override string Use(GameState gameState)
        {
            if (gameState.ContainsItem(gameState.RoomManager.CurrentRoom.RoomItems, "LADDER"))
            {
                if (IsCovered)
                {
                    return $"The {Name} is obscured in a bolted cover.";
                }
                if (!(gameState.GetItem("FLASHLIGHT") is Flashlight flashlight && flashlight.IsOn))
                {
                    return $"It's very dark inside the {Name} shaft." +
                        $" I should find a light source.";
                }
                return IsCovered ? $"The {Name} is obscured in a bolted cover." : gameState.RoomManager.SetCurrentRoom("ventShaft");
            }
            return "That's too high for me to reach.";
        }
    }
}
