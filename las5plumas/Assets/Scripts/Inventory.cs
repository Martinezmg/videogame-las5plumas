using System;
using System.Collections;
using System.Collections.Generic;
using Project.ScriptableObjects;
using UnityEngine;

namespace Project.Game
{
    public class Inventory : MonoBehaviour
    {
        #region Singleton

        public static Inventory inventory;

        private void Awake()
        {
            if (inventory != null)
            {
                Debug.LogWarning("There is mora than one inventory instance.");
                return;
            }

            inventory = this;
        }
        #endregion

        public event Action inventoryUpdated;

        public List<Item_SO> items = new List<Item_SO>();
        public int defaultSize = 5;

        public bool Add(Item_SO item)
        {
            if (items.Count < defaultSize)
            {
                items.Add(item);

                if (inventoryUpdated != null)
                    inventoryUpdated();

                return true;
            }

            return false;
        }

        public void Delete(Item_SO item)
        {
            if (inventoryUpdated != null)
                inventoryUpdated();

            items.Remove(item);
        }
    }
}
