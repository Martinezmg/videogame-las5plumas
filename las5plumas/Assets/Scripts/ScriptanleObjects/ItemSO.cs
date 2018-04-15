using UnityEngine;

namespace Project.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New item", menuName ="ScriptableObjects/Item")]
    public class ItemSO : ScriptableObject
    {
        public new string name = "New item";

        public ActionType actionType;
        private int count;

        public int Count { get { return count; } }
    }
}