using UnityEngine;


namespace Project.DialogueSystem
{
    public class DialogueComponent : MonoBehaviour
    {
        public Dialogue dialogue;

        public bool runOnce = true;
        public bool condition = true;

        public bool Condition { get { return condition; } set { condition = value; } }


        public void StartDialogue()
        {
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
