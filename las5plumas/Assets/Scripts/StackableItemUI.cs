using UnityEngine;
using TMPro;

namespace Project.UI
{
    public class StackableItemUI : ItemContainerUI
    {
        [SerializeField]
        private TextMeshPro textLayout;

        private void Start()
        {
            int count = Inventory.Instance.GetStack(itemName);

            if (count > 1)
            {
                textLayout.text = "x" + count.ToString();
            }
        }

        public override void UpdateItem(Item item)
        {
            if (item.name != itemName)
            {
                return;
            }

            base.UpdateItem(item);

            int count = Inventory.Instance.GetStack(item.name);

            if (count >= 2)
            {
                textLayout.text = "x" + count.ToString();
            }
        }
    }
}
