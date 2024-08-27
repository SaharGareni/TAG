using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied

{
    public static class GameInitializer
    {
        public static CommandParser Initialize()
        {
            var firstRoom = new FirstRoom();
            var roomManager = new RoomManager(firstRoom);
            var gameState = new GameState(roomManager);
            var playerFunctions = new PlayerFunctions(gameState);
            var commandParser = new CommandParser(playerFunctions);
            Console.WriteLine("You wake up in a dark room, your body bound by a ROPE to a CHAIR.");
            Console.WriteLine("It is so dark you barely make out the WALLs surrounding you.");
            Console.WriteLine("Use the \"Inspect\", \"Use\", \"Use something on something...\", \"Take\" and \"Go\" commands to interact ");
            Console.WriteLine("And the 4 cardinal directions, \"North\", \"East\", \"South\" and \"West\" to navigate.");
            return commandParser;
        }
    }
}
