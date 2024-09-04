using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied

{
    internal interface IItemActions
    {
        public interface IItemActions
        {
            string Take(GameState gameState);
            string Inspect(GameState gameState);
            string Use(GameState gameState);
            string UseOn(Item targetItem, GameState gameState);
        }

    }
}
