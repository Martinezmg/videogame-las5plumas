using UnityEngine;

namespace Project.UI
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SelectorInventoryUI : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        private Transform target;
        private bool isSelecting = false;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Select(Transform t)
        {
            if (target != null && t == target)
            {
                Unselect();
            }

            isSelecting = true;
            target = t;
            
            spriteRenderer.enabled = true;
            
        }

        public void Unselect()
        {
            isSelecting = false;
            target = null;
            spriteRenderer.enabled = false;
        }
        
        public void UpdateSelector()
        {
            if (target != null)
            {
                
            }
        }
    }
}
