using UnityEngine;

namespace Project.Interactables
{
    public class Pickable : Interactable
    {
        public override void Interact()
        {
            base.Interact();

            Debug.Log("Pick " + name);

            //Add Coin to inventort

            //player anim for destroy

            //destroy coin

        }
    }
}
