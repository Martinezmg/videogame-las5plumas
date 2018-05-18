using UnityEngine;

namespace Project.Testing
{
    public class Tree : Interactable
    {
        public GameObject treeObject;

        private const ItemAction action = ItemAction.ATTACK;

        public override void Use(Item item)
        {
            if (item.action_ == action && item != null)
            {
                ChopTreeDaown(item);
            }
        }

        public void ChopTreeDaown(Item axe)
        {
            axe.Use(); // <-- dentro de esa funcion el hacha deberia ejecutar la animacion cortar

            Destroy(treeObject);
        }
    }
}
