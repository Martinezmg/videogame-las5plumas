using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Testing
{
    public class ItemLooteable : Interactable
    {
        public Item item_;

        public override void Use(Item item)
        {
            base.Use(item);

            item_.Take();

            Destroy(gameObject);
        }
    }
}
