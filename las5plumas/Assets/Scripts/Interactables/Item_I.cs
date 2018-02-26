using UnityEngine;
using Project.Game;
using Project.ScriptableObjects;

namespace Project.Interactables
{
    [RequireComponent(typeof(Item_SO))]
    public class Item_I : Interactable
    {
        public Item_SO item;

        public override void MeleeAction()
        {
            base.MeleeAction();

            if (Inventory.inventory.Add(item))
            {
                //Animation if is needed
                Debug.Log("item " + name + " added to inventory");
                GameObject.Destroy(gameObject);
            }

        }
    }
}
