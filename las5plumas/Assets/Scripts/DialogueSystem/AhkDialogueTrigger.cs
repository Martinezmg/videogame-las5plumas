using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Game;
using Project.Interactables;

    namespace Project.DialogueSystem
{

    public class AhkDialogueTrigger : Interactable
    {

        public AhkitobeEngine ahkitobe;

        public Dialogue dialogue;

        public override void Interact(ItemAction cmd)
        {
            //base.Interact(cmd);

            DialogManager.Instance.StartDialogue(dialogue);
        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.tag == "Player")
            {
                //DialogManager.Instance.StartDialogue(dialogue);
                ahkitobe.dialogPop.SetActive(true);
                ahkitobe.agent.updateRotation = false;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Player")
            {
                ahkitobe.transform.LookAt(other.transform);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                //DialogManager.Instance.StartDialogue(dialogue);
                ahkitobe.dialogPop.SetActive(false);
                ahkitobe.agent.updateRotation = true;
            }
        }

        
    }
}
