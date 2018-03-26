using UnityEngine;

namespace Project.Interactables
{
    [RequireComponent(typeof(Collider))]
    public class Interactable: MonoBehaviour
    {
        public bool debug = false;

        public string CMD { get; protected set; }
        public string CurrentState { get; protected set; }

        protected StateMachine SM;

        public virtual void Interact(string cmd)
        {
            if (debug)
                Debug.Log("Interacted with " + gameObject.name);

            if (SM.MoveNext(cmd))
            {
                SM.CurrentState();
                CurrentState = SM.CurrentState.Method.Name;
            }
        }
    }
}
