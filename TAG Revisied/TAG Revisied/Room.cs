﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied

{
    public abstract class Room : IRoomActions
    {
        public string Name { get;}
        public string DisplayName { get; }
        public string Description { get; set; }
        public List<Item> RoomItems { get;}
        public bool HasBeenEntered { get; set; } 
        protected Room(string name, string displayName, string description)
        {
            Name = name;
            DisplayName = displayName;
            Description = description;
            RoomItems = new List<Item>();
        }
        public virtual string Enter()
        {
            if (HasBeenEntered)
            {
                return $"You enter the {DisplayName}.";
            }
            HasBeenEntered = true;
            return GetFirstEntryMessage();
        }
        public virtual void Exit() { }
        public virtual string Go(string target,GameState gameState)
        {
            switch (target)
            {
                case "NORTH":
                    return HandleNorth(gameState);
                case "EAST":
                    return HandleEast(gameState);
                case "SOUTH":
                    return HandleSouth(gameState);
                case "WEST":
                    return HandleWest(gameState);
                default:
                    return "I can't go there.";


            }
        }
        public virtual string Inspect(GameState gameState)
        {
            return Description;
        }
        protected virtual string HandleNorth(GameState gameState)
        {
            return "Nothing happens.";
        }
        protected virtual string HandleEast(GameState gameState)
        {
            return "Nothing happens.";
        }
        protected virtual string HandleSouth(GameState gameState)
        {
            return "Nothing happens.";
        }
        protected virtual string HandleWest(GameState gameState)
        {
            return "Nothing happens.";
        }
        protected virtual string GetFirstEntryMessage()
        {
            return $"You enter the {Name}";
        }


        //probably not needed just clutter VV
        //public void AddItem(Item item)
        //{
        //    RoomItems.Add(item);
        //}
        //public void RemoveItem(Item item) { RoomItems.Remove(item); }

    }
}
