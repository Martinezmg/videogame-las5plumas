using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public enum ItemAction
    {
        USE, OPEN, ATTACK, BURN, NONE
    }

    [CreateAssetMenu(fileName = "New Inventory", menuName = "ScriptableObjects/Inventory")]
    public class InventorySO : ScriptableObject
    {
        public List<Item> listOfitems;

        public int coins = 0;
        public int shards = 0;
        public int keys = 0;        
        
    }
}
