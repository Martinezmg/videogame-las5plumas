using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Testing
{
    public class InventoryManager : Singleton<InventoryManager>
    {
        protected InventoryManager() { }

        //public Inventory inventory;
        public SelectorUI selector;
    }
}
