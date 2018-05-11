using UnityEngine;

namespace Project.DialogueSystem
{
    
    public class AnimDialogueTrigger : MonoBehaviour
    {
        public Animator anim;

        public Dialogue dialogue;

        private bool condition = true;

        public bool Condition
        {
            get
            {
                return condition;
            }

            set
            {
                condition = value;
            }
        }

        public void AnimationCompleted()
        {
            if (Condition)
                DialogManager.Instance.StartDialogue(dialogue);
        }
    }
}
