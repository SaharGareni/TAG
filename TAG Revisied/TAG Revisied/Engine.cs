using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied
{
    public class Engine : Item  
    {
        public bool IsOn { get; set; }
        public bool IsFueled { get; set; }
        public Engine() : base("ENGINE","It's driving the PISTON with force. It also seems to power the lighting of the room.",false) { }
        public override string Inspect(GameState gameState)
        {
            return IsOn ? $"It's dormant, as if it hasn't been used in a while. Looks to be connected to a large PISTON." : Description;
        }
        public override string Use(GameState gameState)
        {
            if (IsFueled)
            {
                IsOn = true;
                //VV Unsafe version commented
                //((EngineRoom)gameState.RoomManager.CurrentRoom).IsEngineOn = true;
                if (gameState.RoomManager.CurrentRoom is EngineRoom engineRoom)
                {
                    engineRoom.IsEngineOn = true; 
                }
                return $"You turn on the {Name}." +
                    $"As it lights up the room, the mechanical hum and the eerie flicker of fluorescent lights shatter the stillness." +
                    $"The PISTON connected to the {Name} starts to lift and drop with a violent rhythm.";
            }
            return "You attempt to activate the machine. It shudders briefly, then falls silent.";
        }
    }
}
