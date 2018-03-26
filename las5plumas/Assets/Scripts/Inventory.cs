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

        //trigger actions each time inventory object is updated
        public event Action inventoryUpdated;
        private void InventoryUpdate() { if (inventoryUpdated!=null) inventoryUpdated(); }

        //stackable
        private Dictionary<string, int> items;
                
        public GameObject axe;
        public GameObject sword;
        public GameObject bow;
        public GameObject hammer;

        private GameObject objectEquipped;

        public GameObject lighter;

        private bool potion1;
        private bool potion2;

        private bool scroll;

        private void Start()
        {
            //cargar datos de la base de datos

            //mientras tanto
            items = new Dictionary<string, int>
            {
                {"keys",   0},
                {"coins",  0},
                {"tokens", 0},
                {"orange", 0},
                {"green",  0},
                {"blue",   0},
                {"purple", 0},
            };
        }

        public void AddItem(string itemName)
        {
            items[itemName]++;

            InventoryUpdate();
        }

        public bool UseItem(string itemName)
        {
            Debug.Assert(!(items[itemName] < 0), itemName + " no puede ser menos que 0");

            if (items[itemName] == 0)
                return false;

            items[itemName]--;

            InventoryUpdate();

            return true;
        }

        public bool EquipAxe()
        {
            if (axe == null)
            {
                return false;
            }

            objectEquipped = axe;

            InventoryUpdate();

            return true;
        }
        public bool EquipSword()
        {
            if (sword == null)
            {
                return false;
            }

            objectEquipped = sword;
            InventoryUpdate();

            return true;
        }
        public bool EquipBow()
        {
            if (bow == null)
            {
                return false;
            }

            objectEquipped = bow;
            InventoryUpdate();

            return true;
        }
        public bool EquipHammer()
        {
            if (hammer == null)
            {
                return false;
            }

            objectEquipped = hammer;
            InventoryUpdate();

            return true;
        }

        public void UnequipObject()
        {
            if (objectEquipped != null)
            {
                objectEquipped = null;

                InventoryUpdate();
            }
                
        }

        public bool UsePotion1()
        {
            if (potion1)
            {
                potion1 = !potion1;
                InventoryUpdate();

                return true;
            }

            return false;
        }
        public bool UsePotion2()
        {
            if (potion2)
            {
                potion2 = !potion2;
                InventoryUpdate();

                return true;
            }

            return false;
        }

        public bool TakePotion1()
        {
            if (potion1)
            {
                return false;
            }

            potion1 = !potion1;

            InventoryUpdate();

            return true;
        }
        public bool TakePotion2()
        {
            if (potion2)
            {
                return false;
            }

            potion2 = !potion2;

            InventoryUpdate();

            return true;
        }


    }
}
