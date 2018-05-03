using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Testing
{
    public enum ItemAction
    {
        USE, UNLOCK, BURN, ATTACK
    }

    //[Serializable]
    [CreateAssetMenu(fileName = "New item", menuName = "ScriptableObjects/Testing/Item")]
    public class Item : ScriptableObject
    {
        public ItemAction action_;
        
        public event Action ItemUsed;

        public virtual void Use()
        {
            if (ItemUsed != null)
                ItemUsed();
        }
    }
}
