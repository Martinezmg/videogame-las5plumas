using UnityEngine.Events;

namespace Project.Testing.ChestSM
{
    public class Rope : Interactable
    {
        private const ItemAction CUT = ItemAction.ATTACK;

        public UnityEvent OnCut;

        public override void Use(Item item)
        {
            if (item != null && item.action_ == CUT)
            {
                item.Use();

                if (OnCut != null)
                {
                    OnCut.Invoke();
                }
            }
        }
    }
}
