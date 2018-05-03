using System;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Testing
{
    [Serializable]
    public class IntEvent : UnityEvent<int> { }

    [CreateAssetMenu(fileName = "New stackeable container", menuName = "Testing/Stackeable container"), Serializable]
    public class StackeableContainer : Container
    {
        public IntEvent OnCountChange;
        [SerializeField]
        private int count_;

        protected override void Start()
        {
            base.Start();
        }

        public override void UseItem()
        {
            if (count_ <= 0)
            {
                return;
            }

            count_--;

            OnCountChange.Invoke(count_);
        }

        public override bool StoreItem(string itemName)
        {        
            if (itemName == item_.name)
            {
                count_++;

                OnCountChange.Invoke(count_);

                if (count_ == 1)
                    ItemStored.Invoke();

                return true;
            }

            return false;
        }

    }
}
