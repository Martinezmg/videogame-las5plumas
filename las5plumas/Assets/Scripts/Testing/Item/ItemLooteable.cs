using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Testing
{
    public class ItemLooteable : Interactable
    {
        public UnityEvent OnDestroyy;

        public Item item_;

        public override void Use(Item item)
        {
            base.Use(item);

            item_.Take();

            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            OnDestroyy.Invoke();
        }
    }
}
