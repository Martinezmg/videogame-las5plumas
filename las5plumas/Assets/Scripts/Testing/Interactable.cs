using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Testing
{
    public class Interactable : MonoBehaviour
    {

        public bool active = true;
        public bool Active { get { return active; } set { active = value; } }

        public virtual void Touch() { }

        public virtual void Use(Item item)
        {
            if (!active)
            {
                return;
            }
        }
    }
}
