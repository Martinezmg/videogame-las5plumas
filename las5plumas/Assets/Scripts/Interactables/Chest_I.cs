using UnityEngine;

namespace Project.Interactables
{
    public class Chest_I : Interactable
    {
        public Interactable item;

        public override void SpecialAction()
        {
            Debug.Log("animacion de abrir el cofre ***");
            if (item != null)
                item.interactActive = true;
        }
    }
}
