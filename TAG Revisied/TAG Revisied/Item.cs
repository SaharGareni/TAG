using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied

{
    public abstract class Item : IItemActions
    {
        public string Name { get; }
        public string Description { get; }
        public bool IsObtainable { get; }

        protected Item(string name, string description, bool isObtainable)
        {
            Name = name;
            Description = description;
            IsObtainable = isObtainable;
        }

        public virtual string Take(GameState gameState)
        {
            if (!IsObtainable)
            {
                return "I can't take that.";
            }
            if (gameState.RoomManager.CurrentRoom.RoomItems.Contains(this))
            {
                return gameState.TakeItemFromSource(this, gameState.RoomManager.CurrentRoom.RoomItems);
            }
            if (gameState.ConditionalItems.Contains(this))
            {
                return gameState.TakeItemFromSource(this, gameState.ConditionalItems);
            }
            return "I can't take that.";
        }
        public virtual string Inspect(GameState gameState)
        {
            return Description ;
        }
        public virtual string Use(GameState gameState)
        {
            return "Nothing interesting happens.";
        }
        public virtual string UseOn(Item targetItem, GameState gameState)
        {
            return "Nothing interesting happens.";
        }
    }

}
