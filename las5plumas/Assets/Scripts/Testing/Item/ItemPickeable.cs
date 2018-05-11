using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Project.Testing
{
    public class ItemPickeable : Interactable
    {
        public Item item_;

        public UnityEvent OnTouch;

        public override void Touch()
        {
            OnTouch.Invoke();

            item_.Take();
        }
    }
}
