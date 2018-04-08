using UnityEngine;

namespace Project.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New item", menuName ="ScriptableObjects/Item")]
    public class Item_SO : ScriptableObject
    {
        public new string name = "New item";

        public virtual void Use() { }
    }
}