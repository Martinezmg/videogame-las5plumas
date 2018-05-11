using System;
using UnityEngine;

namespace Project.Testing
{
    public enum ItemAction
    {
        USE, UNLOCK, BURN, ATTACK
    }

    [CreateAssetMenu(fileName = "New item", menuName = "Testing/Item")]
    public class Item : ScriptableObject
    {
        public event Action OnUse;
        public event Action OnTake;

        //public string name_;
        public ItemAction action_;

        public virtual void Use()
        {
            Invoke(OnUse);
        }

        public virtual void Take()
        {
            Invoke(OnTake);
        }

        private void Invoke(Action e)
        {
            if (e != null)
                e();
        }
    }
}
