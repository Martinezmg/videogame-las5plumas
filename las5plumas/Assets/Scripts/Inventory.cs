﻿using System;
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
        public event Action<string> InventoryUpdated;
        

        public bool update = false;

        //DB
        public InventorySO inventoryDB;
        public List<ItemUI> inventoryUI = new List<ItemUI>();



        private void Start()
        {
            /*foreach (var item in inventoryDB.items)
            {
                if(!inventoryUI.Contains(new ItemUI(item.name)))
                    inventoryUI.Add(new ItemUI(item.name));
            }*/

            foreach (var item in inventoryDB.items)
            {
                InventoryUpdate(item);
            }
        }

        private void Update()
        {
            if (update)
            {
                update = false;

                foreach (var item in inventoryDB.items)
                {
                    InventoryUpdate(item);
                }

            }
        }

        public void AddItem(string itemName)
        {
            Item i;

            if(inventoryDB.AddItem(itemName, out i))
            {
                InventoryUpdate(i);
            }
        }

        public void UseItem(string itemName)
        {
            Item i;

            if (inventoryDB.UseItem(itemName, out i))
            {
                InventoryUpdate(i);
            }
        }

        public void EquipItem(string itemName)
        {
            Item i;

            if (inventoryDB.EquipItem(itemName, out i))
            {
                InventoryUpdate(i);
            }
        }

        private void InventoryUpdate(Item item)
        {
            ItemUI itemUI = inventoryUI.Find(x => x.name == item.name);

            if (item != null)
            {
                if (item.quantity <= 0)
                {
                    //this part should be execute by a corutine when player goes to inventory, 
                    //Color c = itemUI.sprite.color;
                    //itemUI.sprite.color = new Color(c.r, c.g, c.b, 0f);
                    StartCoroutine("FadeItemOut", itemUI);
                }
                else if (item.quantity == 1)
                {
                    //this part should be execute by a corutine when player goes to inventory, 
                    //Color c = itemUI.sprite.color;
                    //itemUI.sprite.color = new Color(c.r, c.g, c.b, 255f);
                    StartCoroutine("FadeItemIn", itemUI);
                }
                else
                {
                    //increase counter of the item if it supports it
                    Debug.Log("Count: " + item.quantity.ToString());
                }
            }
        }

        private IEnumerator FadeItemIn(object item)
        {
            ItemUI nitem = item as ItemUI;

            Color c = nitem.sprite.color;
            float t = 1f;
            float a = 0f;

            /* while (a < 255f)
             {
                 nitem.sprite.color = new Color(c.r, c.g, c.b, Mathf.Lerp(a, 255f, t * Time.deltaTime));

                 yield return null;
             }*/
            nitem.sprite.color = new Color(c.r, c.g, c.b, 255f);
            yield return null;

        }
        private IEnumerator FadeItemOut(object item)
        {
            ItemUI nitem = item as ItemUI;

            Color c = nitem.sprite.color;
            float t = 1f;
            float a = 255f;

            /*while (a > 0f)
            {
                nitem.sprite.color = new Color(c.r, c.g, c.b, Mathf.Lerp(a, 0f, t * Time.deltaTime));

                yield return null;
            }*/
            nitem.sprite.color = new Color(c.r, c.g, c.b, 0f);
            yield return null;
        }




    }
}
