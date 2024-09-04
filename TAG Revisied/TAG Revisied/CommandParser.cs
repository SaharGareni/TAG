using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TAG_Revisied

{
    public class CommandParser
    {
        private readonly PlayerFunctions _playerFunctions;
        public CommandParser(PlayerFunctions playerFunctions)
        {
            _playerFunctions = playerFunctions;
        }
        public string Parse(string command)
        {          
            if (string.IsNullOrWhiteSpace(command))
            {
                return "Please enter a command.";
            }
            command = command.ToUpper();
            string[] parts = command.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
            string action = parts[0];
            string argument = parts.Length > 1 ? parts[1] : " ";
            //WORK IN PROGRESS
            switch (action)
            {
                case "USE":
                   Match match = Regex.Match(argument, @"^(.+)\s+on\s+(.+)$", RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        string itemName = match.Groups[1].Value;
                        string targetItem = match.Groups[2].Value;
                         return _playerFunctions.UseOn(itemName, targetItem);
                    }
                    else
                    {
                       return _playerFunctions.Use(argument);
                    }
                case "TAKE":
                    return _playerFunctions.Take(argument);
                case "INSPECT":
                    return _playerFunctions.Inspect(argument);
                case "GO":
                    return _playerFunctions.Go(argument);
                default:
                    return "I don't understand.";
            }
        }
    }
}
