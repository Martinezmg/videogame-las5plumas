using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.DialogueSystem
{
    
    public class ColliderDialogueTrigger : MonoBehaviour
    {
        public Transform target;

        public Dialogue dialogue;

        private bool condition = true;

        public bool runOnce = true;

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

        private void OnTriggerEnter(Collider other)
        {
            if (dialogue == null)
                return;

            if (other.gameObject.name == "Player" && condition)
            {
                DialogManager.Instance.StartDialogue(dialogue);

                if (runOnce)
                    dialogue = null;
            }
                
        }
    }
}
