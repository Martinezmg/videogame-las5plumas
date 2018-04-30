using System;
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

            Item i = Inventory.Instance.inventoryDB.listOfitems.Find(x => x.name == itemName);

            if (i!=null && i.available)
            {
                render.enabled = true;
            }
            else
            {
                render.enabled = false;
            }
        }

        private void OnDisable()
        {
            tapGesture.Tapped -= UseItem;
        }

        private void UseItem(object sender, EventArgs e)
        {
            Inventory.Instance.selector.Select(transform);
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
