using UnityEngine;

namespace Project.UI
{
    public class SelectorInventoryUI : MonoBehaviour
    {
        Transform target;

        public void Select(Transform t)
        {
            target = t;
        }

        public void Unselect()
        {
            target = null;
        }
        
        public void UpdateSelector()
        {
            if (target != null)
            {
                
            }
        }
    }
}
