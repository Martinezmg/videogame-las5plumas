using UnityEngine;
using Project.UI;

namespace Project.Interactables
{
    public class Pickable : Interactable
    {
        public string itemName;
        public Animator anim;

        private int triggerHash = Animator.StringToHash("PickedUp"); 

        public override void Interact()
        {
            base.Interact();

            Debug.Log("Pick " + name);

            //Add Coin to inventort
            Inventory.Instance.AddItem(itemName);

            //player anim for destroy
            if (anim != null)
            {
                anim.SetTrigger(triggerHash);
            }
            else
            {
                PickedUp();
            }

            
        }

        public void PickedUp()
        {
            //destroy coin
            Destroy(gameObject);
        }


    }
}
