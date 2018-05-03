using System;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Testing
{
    [Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    [CreateAssetMenu(fileName = "New consumable container", menuName = "Testing/Consumable container"), Serializable]
    public class ConsumableContainer : Container
    {
        public BoolEvent OnAvailableChange;

        protected override void Start()
        {
            base.Start();
        }

        public override void UseItem()
        {
            if (!available)
            {
                return;
            }

            available = false;

            OnAvailableChange.Invoke(available);
        }

        public override bool StoreItem(string itemName)
        {
            if (base.StoreItem(itemName))
            {
                OnAvailableChange.Invoke(available);

                return true;
            }

            return false;
        }
    }
}
