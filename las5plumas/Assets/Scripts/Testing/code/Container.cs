using System;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Testing
{
    [CreateAssetMenu(fileName = "New container", menuName = "Testing/Container"), Serializable]
    public class Container : ScriptableObject
    {
        public Item item_;
        public bool available;
        public UnityEvent ItemStored;

        protected virtual void Start()
        {
            if (item_ != null)
            {
                item_.ItemUsed += UseItem;
            }
        }

        public virtual void UseItem()
        {
            
        }

        public virtual bool StoreItem(string itemName)
        {
            if (itemName == item_.name && !available)
            {
                available = true;

                ItemStored.Invoke();

                return true;
            }

            return false;
        }
    }
}
