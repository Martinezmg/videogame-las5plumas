using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "ScriptableObjects/Inventory")]
    public class InventorySO : ScriptableObject
    {
        public List<Item> items = new List<Item>
        {
            new Item("feather1", 0),
            new Item("feather2", 0),
            new Item("feather3", 0),
            new Item("feather4", 0),
            new Item("feather5", 0),

            new Item("moons", 0),
            new Item("coins", 0),

            new Equipable("axe", 0),
            new Equipable("bow", 0),
            new Equipable("sword", 0),
            new Equipable("hammer", 0),

            new Equipable("ligther", 0),
            new Item("keys", 0),
            new Item("potion1", 0),
            new Item("potion2", 0),

            new Item("scroll", 0),
            new Item("orange", 0),
            new Item("green", 0),
            new Item("blue", 0),
            new Item("purple", 0),

        };

        public bool AddItem(string itemName, out Item item)
        {
            item = items.Find(x => x.name == itemName);

            if (item != null)
            {
                item.quantity++;
                return true;
            }

            return false;
        }

        public bool UseItem(string itemName, out Item item)
        {
            item = items.Find(x => x.name == itemName);

            if (item != null)
            {
                if (item.quantity <= 0)
                    return false;                

                //item.quantity++;

                return true;
            }

            return false;
        }

        public bool EquipItem(string itemName, out Item item)
        {
            Equipable iteme = items.Find(x => x.name == itemName) as Equipable;
            item = iteme;

            if (iteme != null)
            {
                if (iteme.quantity <= 0)
                    return false;

                //equip item in player
                iteme.equiped = true;
                
                return true;
            }

            return false;
        }
    }
}
