using UnityEngine;
using Project.UI;

namespace Project.Interactables
{
    public class Storeable : Interactable
    {
        public string itemName;

        public override void Interact()
        {
            //base.Interact(cmd);

            Inventory.Instance.AddItem(itemName);

            Destroy(gameObject);
        }
    }

}

