using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Testing
{
    [CreateAssetMenu(fileName = "New inventory", menuName = "Testing/Inventory")]
    public class Inventory : ScriptableObject
    {
        public Container[] slots_;
    }
}
