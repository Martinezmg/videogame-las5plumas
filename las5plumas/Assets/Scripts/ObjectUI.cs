using UnityEngine;
using UnityEngine.UI;
using Project.Game.Player;

namespace Project.UI
{
    public class ObjectUI : MonoBehaviour
    {
        public Image spriteContainer;

        public PlayerActioner player;
        //public ItemUI item;

        //public void EquipObjectUI(ItemUI i)
       // {
       //     item = i;/
//
//            spriteContainer.sprite = i.sprite.sprite;
//        }

        public void UseObject(bool activeObject)
        {
            if (activeObject)
            {
                //player.CurrentAction = item.action;
            }
            else
            {
                player.CurrentAction = PlayerActioner.defaultAction;
            }
        }

    }
}
