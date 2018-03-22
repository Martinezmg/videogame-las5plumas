using UnityEngine;

namespace Project.Interactables
{
    public class Interactable: MonoBehaviour
    {
        public bool debug = false;

        public virtual void Interact()
        {
            if (debug)
                Debug.Log("Interacted with " + gameObject.name);
        }
    }
}
