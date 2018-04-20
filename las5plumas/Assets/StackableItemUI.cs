using UnityEngine;
using TMPro;

namespace Project.UI
{
    public class StackableItemUI : ItemContainerUI
    {
        [SerializeField]
        private TextMeshPro textLayout;

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
                textLayout.text = count.ToString();
            }
        }
    }
}
