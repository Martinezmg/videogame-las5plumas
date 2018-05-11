using System;
using UnityEngine;

namespace Project.Testing
{
    [CreateAssetMenu(fileName = "New container", menuName = "Testing/Inventory/Container")]
    public class Container : ScriptableObject
    {        
        public Item item_;

        [SerializeField]
        protected bool available_;
        
        public string StoredItemName { get { return item_.name; } }

        public virtual bool Available
        {
            get { return available_; }
            protected set { available_ = value;}
        }
        
        private void Awake()
        {
            //Debug.Log(name + " awakenign");
        }

        public virtual void StoreItem()
        {
            if (!Available)
            {
                Available = true;

                Debug.Log("Item " + item_.name + " se guardó en el inventario.");                
            }
        }

        public virtual void Set()
        {
            if (item_ != null)
            {
                item_.OnTake += StoreItem;
            }
        }
    }
}
