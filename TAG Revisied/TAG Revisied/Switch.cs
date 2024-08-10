using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied
{
    public class Switch : Item
    {
        public bool SwitchOff;
        public Switch() : base("SWITCH", "A plastic ornament mounted on the WALL. Should I press it?",false) { SwitchOff = true; }
        public override string Take(GameState gameState)
        {
            if (gameState.IsPlayerBound())
            {
                return "You are bound.";
            }
            return "It serves better purpose on the WALL.";
        }
        public override string Inspect(GameState gameState)
        {
            if (gameState.IsPlayerBound())
            {
                return "You are bound.";
            }
            return Description;
        }
        public override string Use(GameState gameState)
        {
            if (gameState.IsPlayerBound())
            {
                return "You are bound.";
            }
            //edit the return strings hereto indiacte that light fills the room while lightbulb is not taken and else show the thing below
            SwitchOff = !SwitchOff;
            if (gameState.Inventory.Any(i => i is Lightbulb))
            {
             return SwitchOff ? $"You press the {Name}, cutting power to the socket." : $"You press the {Name}, giving power to the LIGHTBULB socket.";  
            }
            return SwitchOff ? "You press the SWITCH, turning off the light in the process" : "Light bursts from the ceiling-mounted LIGHTBULB, filling the room.";
        }
        public override string UseOn(Item targetItem, GameState gameState)
        {
            if (gameState.IsPlayerBound())
            {
                return "You are bound.";
            }
            return base.UseOn(targetItem, gameState);
        }
    }
}
