using UnityEngine;
using UnityEngine.UI;
using Project.Testing;

namespace Project.UI
{
    public class ObjectUI : MonoBehaviour
    {
        public PlayersItem itemEquipped;
        public Sprite defaultSprite;

        private Image thisSprite;

        private void Start()
        {
            itemEquipped.PlayerItemUpdated += updateSprite;
            thisSprite = GetComponent<Image>();
        }

        private void OnDestroy()
        {
            itemEquipped.PlayerItemUpdated -= updateSprite;
        }

        private void updateSprite()
        {
            Container currentItemContainer = itemEquipped.ItemContainer;

            if (currentItemContainer != null)
            {
                Sprite currentItemSprite = currentItemContainer.item_.spriteGUI;

                if (currentItemSprite != null)
                    thisSprite.sprite = itemEquipped.ItemContainer.item_.spriteGUI;
                else
                    thisSprite.sprite = defaultSprite;
            }else
                thisSprite.sprite = defaultSprite;

        }
    }
}
