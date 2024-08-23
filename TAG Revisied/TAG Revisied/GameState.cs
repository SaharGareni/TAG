using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TAG_Revisied
{
    public class GameState
    {
        public RoomManager RoomManager { get; }
        public List<Item> Inventory { get; }
        //DerivedItems is only used for when items need to be taken from another item
        //should not be used anywhere else
        public List<Item> ConditionalItems { get; }
        public GameState(RoomManager roomManager)
        {
            RoomManager = roomManager;
            Inventory = new List<Item>();
            ConditionalItems = new List<Item>();
        }
        public Item GetItem(string itemName)
        {
            itemName = itemName.ToUpper();
            var item = Inventory.FirstOrDefault(i => i.Name == itemName);
            if (item == null)
            {
                item = RoomManager.CurrentRoom.RoomItems.FirstOrDefault(i => i.Name == itemName);
            }
            //if (item == null)
            //{
            //    item = ConditionalItems.FirstOrDefault(i => i.Name == itemName);
            //}
   //commenting this because i dont actually want the getItem to get me conditional items currently
            return item;
        }
        public bool ContainsItem (List<Item> list,string itemName)
        {
            itemName = itemName.ToUpper();
            return list.Any(item => item.Name == itemName);
        }
        public void AddItemToInventory(Item item)
        {
            Inventory.Add(item);
        }
        public void RemoveItemFromInventory(Item item)
        {
            Inventory.Remove(item);
        }
        public void AddConditionalItem(Item item)
        {
            ConditionalItems.Add(item);
        }
        public void RemoveConditionalItem(Item item)
        {
            ConditionalItems.Remove(item);
        }
        public void AddRoomItem(Item item)
        {
            RoomManager.CurrentRoom.RoomItems.Add(item);
        }
        //VV temporary solution to make it so "FirstRoom.IsBoundCoun" can affect the rest of the actions VV
        public bool IsPlayerBound()
        {
            if (RoomManager.CurrentRoom is FirstRoom firstRoom && firstRoom.IsBoundCount < 3)
            {
                return true;
            }
            return false;
        }
        public string TakeItemFromSource(Item item, List<Item> sourceInventory)
        {
            sourceInventory.Remove(item);
            Inventory.Add(item);
            return $"You take the {item.Name}.";
        }
        public void MoveConditionalItem(string itemName,List<Item> list)
        {
            itemName = itemName.ToUpper();
            var item = ConditionalItems.FirstOrDefault(i => i.Name == itemName);
            if (item != null)
            {
                list.Add(item);
                ConditionalItems.Remove(item);
            }
            else
            {
                Console.WriteLine($"FOR DEBUGGING: COULD NOT TRANSFER {itemName} to {list}. REFRENCED ITEM IS NULL");
            }
        }
    }
}
