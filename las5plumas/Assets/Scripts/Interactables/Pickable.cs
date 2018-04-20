using UnityEngine;
using Project.UI;

namespace Project.Interactables
{
    public class Pickable : Interactable
    {
        public string itemName;

        public override void Interact()
        {
            base.Interact();

            Debug.Log("Pick " + name);

            //Add Coin to inventort
            Inventory.Instance.AddItem(itemName);

            //player anim for destroy


            //destroy coin
            Destroy(gameObject);
        }
    }
}
