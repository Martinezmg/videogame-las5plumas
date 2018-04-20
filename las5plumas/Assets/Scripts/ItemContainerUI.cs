﻿using System;
using TouchScript.Gestures;
using UnityEngine;

namespace Project.UI
{
    [RequireComponent(typeof(TapGesture))]
    public class ItemContainerUI : MonoBehaviour
    {
        private TapGesture tapGesture;
        private SpriteRenderer render;

        public string itemName;

        private void Awake()
        {
            tapGesture = GetComponent<TapGesture>();
            render = GetComponent<SpriteRenderer>();

        }

        private void OnEnable()
        {
            tapGesture.Tapped += UseItem;
            Inventory.Instance.InventoryUpdated += UpdateItem;
        }

        private void OnDisable()
        {
            tapGesture.Tapped -= UseItem;
        }

        private void UseItem(object sender, EventArgs e)
        {
           //from inventoryt
        }

        public virtual void UpdateItem(Item item)
        {
            if (item.name != itemName)
            {
                return;
            }

            if (item.available)
            {
                render.enabled = true;
            }
        }
    }
}
