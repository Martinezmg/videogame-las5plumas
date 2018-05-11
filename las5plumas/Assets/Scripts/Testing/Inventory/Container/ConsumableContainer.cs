using System;
using UnityEngine;

namespace Project.Testing
{
    [CreateAssetMenu(fileName = "New consumable container", menuName = "Testing/Inventory/Consumable Container")]
    public class ConsumableContainer : Container
    {
        public event Action<bool> OnAvailableChange;
        
        public override bool Available
        {
            get
            {
                return base.Available;
            }

            protected set
            {
                base.Available = value;

                if (OnAvailableChange != null)
                    OnAvailableChange(available_);
            }
        }

        public override void StoreItem()
        {
            base.StoreItem();
        }

        public virtual void UpdateContainer()
        {
            Available = false;
        }

        public override void Set()
        {
            if (item_ != null)
            {
                item_.OnTake += StoreItem;
                item_.OnUse += UpdateContainer;
            }
        }
    }
}
