using System;
using System.Collections;
using System.Collections.Generic;
using Project.ScriptableObjects;
using Project.UI;
using UnityEngine;

namespace Project.UI
{
    public class Inventory : Singleton<Inventory>
    {
        #region Singleton
        protected Inventory() { }
        #endregion
        
        //trigger actions each time inventory object is updated
        public event Action<Item> InventoryUpdated;

        //selector
        [SerializeField]
        public SelectorInventoryUI selector;

        //DB
        public InventorySO inventoryDB;

        public void AddItem(string itemName)
        {
            Item item = inventoryDB.listOfitems.Find(x => x.name == itemName);

            if (item == null)
            {
                Debug.LogWarning("PROJECT: " + itemName + " not found in inventory.");
                return;
            }

            //Necesita mejorar el dise;o OJO
            //UpdateUI();

            if (!item.available)
            {
                item.available = true;
                InventoryUpdated(item);
            }

            if (itemName == "coin")
            {
                inventoryDB.coins++;
                InventoryUpdated(item);
            }

            if (itemName == "shard")
            {
                inventoryDB.shards++;
                InventoryUpdated(item);
            }

            if (itemName == "key")
            {
                inventoryDB.keys++;
                InventoryUpdated(item);
            }
            Debug.LogWarning("PROJECT: Item " + itemName + " already added to the inventory.");

        }

        public void UseItem(string itemName)
        {

        }

        public int GetStack(string itenName) 
        {
            if (itenName == "key")
            {
                return inventoryDB.keys;
            }
            else if (itenName == "coin")
            {
                return inventoryDB.coins;
            }
            else if (itenName == "shard")
            {
                return inventoryDB.shards;
            }
            else
            {
                return -1;
            }

        }
        
        
    }
}
