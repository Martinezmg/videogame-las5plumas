using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Project.DialogueSystem
{
    public class DialogueComponent : MonoBehaviour
    {
        public Dialogue dialogue;

        public bool runOnce = true;
        public bool condition = true;
        public float delay = 0f;

        public UnityEvent OnDialogueEnd;

        public bool Condition { get { return condition; } set { condition = value; } }

        private void Start()
        {
            DialogManager.Instance.DialogEnd += OnEnd;
        }

        private void OnDestroy()
        {
            DialogManager.Instance.DialogEnd -= OnEnd;
        }

        private void OnEnd(Dialogue obj)
        {
            if (obj == dialogue && OnDialogueEnd != null) OnDialogueEnd.Invoke();
        }

        public void StartDialogue()
        {
            StartCoroutine(startDialogue());
        }

        private IEnumerator startDialogue()
        {
            yield return (delay <= 0) ? null : new WaitForSeconds(delay);

            if (runOnce)
            {
                if (condition)
                {
                    DialogManager.Instance.StartDialogue(dialogue);
                    condition = false;
                }
            }
            else
            {
                if (condition)
                {
                    DialogManager.Instance.StartDialogue(dialogue);
                }
            }
        }

    }
}
