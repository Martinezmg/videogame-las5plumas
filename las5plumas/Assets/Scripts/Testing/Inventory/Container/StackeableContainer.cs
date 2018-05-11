using System;
using UnityEngine;

namespace Project.Testing
{
    [CreateAssetMenu(fileName = "New stackable container", menuName = "Testing/Inventory/Stackable Container")]
    public class StackeableContainer : ConsumableContainer
    {
        public event Action<int> OnCountChange;

        [SerializeField]
        private int count_;
        
        public int Count
        {
            get
            {
                return count_;
            }
            protected set
            {
                count_ = value;
                
                if (count_ <= 0)
                {
                    Available = false;
                }

                if (count_ > 0 && OnCountChange != null)
                {
                    Available = true;
                    OnCountChange(count_);
                }
            }
        }

        public override bool Available
        {
            get
            {
                return base.Available;
            }

            protected set
            {
                base.Available = value;
            }
        }
        
        public override void StoreItem()
        {
            Count++;
        }

        public int Withdraw(int desireAmount)
        {
            int amount;
            int amountLeft = count_ - desireAmount;

            if (amountLeft < 0)
            {
                amount = count_;
                Count = 0;
            }
            else
            {
                amount = desireAmount;
                Count = amountLeft;
            }

            return amount;
        }

        public override void UpdateContainer()
        {
            Count--;
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
