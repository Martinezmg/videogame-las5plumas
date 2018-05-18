using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Testing
{
    public class InventoryManager : MonoBehaviour
    {
        public static InventoryManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        //public Inventory inventory;
        public SelectorUI selector;
    }
}
