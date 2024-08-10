using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied
{
    public abstract class Room : IRoomActions
    {
        public string Name { get;}
        public string Description { get; set; }
        public List<Item> RoomItems { get;}
        protected Room(string name, string description)
        {
            Name = name;
            Description = description;
            RoomItems = new List<Item>();
        }
        public virtual void Enter() { }
        public virtual void Exit() { }
        public abstract string Go(string target,GameState gameState);
        //probably not needed just clutter VV
        //public void AddItem(Item item)
        //{
        //    RoomItems.Add(item);
        //}
        //public void RemoveItem(Item item) { RoomItems.Remove(item); }

    }
}
