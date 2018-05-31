using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Game;
using Project.Testing;

    namespace Project.DialogueSystem
{

    public class AhkDialogueTrigger : Interactable
    {

        public AhkitobeEngine ahkitobe;

        public Dialogue dialogue;
        public Dialogue extraDialogue;

        public bool enableExtreDialogue = false;

        private Dialogue defaultDialogue;

        private void Start()
        {
            defaultDialogue = dialogue;
        }

        public override void Use(Testing.Item item)
        {
            base.Use(item);

            if (!active)
            {
                return;
            }

            DialogManager.Instance.StartDialogue(defaultDialogue);

            if (enableExtreDialogue)
            {
                defaultDialogue = extraDialogue;
            }
        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.name == "Player")
            {
                //DialogManager.Instance.StartDialogue(dialogue);
                ahkitobe.dialogPop.SetActive(true);
                ahkitobe.agent.updateRotation = false;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.name == "Player")
            {
                ahkitobe.transform.LookAt(other.transform);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.name == "Player")
            {
                //DialogManager.Instance.StartDialogue(dialogue);
                ahkitobe.dialogPop.SetActive(false);
                ahkitobe.agent.updateRotation = true;
            }
        }

        
    }
}
