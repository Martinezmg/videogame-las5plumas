using UnityEngine;

namespace Project.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New item", menuName ="ScriptableObjects/Item")]
    public class ItemSO : ScriptableObject
    {
        [Header("Item name")]
        public new string name = "New item";

        [Header("Data")]
        public ItemAction actionType;
    }
}