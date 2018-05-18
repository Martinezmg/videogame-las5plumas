using UnityEngine;
using UnityEngine.Events;

namespace Project.DialogueSystem
{
    [RequireComponent(typeof(Collider))]
    public class DialogueEventHandler : MonoBehaviour
    {
        public Dialogue dialogue;
        public GameObject activator;

        public UnityEvent OnBegan;
        public UnityEvent OnEnd;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == activator)
            {
                DialogManager.Instance.DialogBegan += DialogBegan;
                DialogManager.Instance.DialogEnd += DialogEnd;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject == activator)
            {
                DialogManager.Instance.DialogBegan -= DialogBegan;
                DialogManager.Instance.DialogEnd -= DialogEnd;
            }
        }

        private void DialogBegan(Dialogue d)
        {
            if (d == dialogue && OnBegan != null)
            {
                OnBegan.Invoke();
            }
        }
        private void DialogEnd(Dialogue d)
        {
            if (d == dialogue && OnEnd != null)
            {
                OnEnd.Invoke();
            }
        }
    }
}
