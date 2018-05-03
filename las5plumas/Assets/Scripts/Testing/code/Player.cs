using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Testing
{
    public class Player : MonoBehaviour
    {
        private int HP;
        private int MP;

        private Item emptyHand;

        private Item item;
        private Item equipableItem; //este deberia ser el arma o lampara, cuando este esta activo 'item' se desactiva

        public void SetItem(Item i)
        {
            if (i == null)
                item = emptyHand;

            item = i;
        }

        public void UseItem(Interactables.Interactable obj)
        {
            //deberia ejecutarse con el actioner
            //obj.Interact(item);
        }
    }
}
