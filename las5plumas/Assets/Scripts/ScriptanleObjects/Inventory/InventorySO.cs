using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public enum ItemAction
    {
        USE, OPEN, ATTACK, BURN, NONE
    }

    [CreateAssetMenu(fileName = "New Inventory", menuName = "ScriptableObjects/Inventory")]
    public class InventorySO : ScriptableObject
    {
        public List<Item> listOfitems;

        public int coins = 0;
        public int shards = 0;
        public int keys = 0;        


        /*public bool AddItem(string itemName, out Item item)
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
        }*/
    }
}
