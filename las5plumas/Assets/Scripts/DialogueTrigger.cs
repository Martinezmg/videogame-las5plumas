using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.DialogueSystem
{
    public class DialogueTrigger : MonoBehaviour
    {
        
        public Dialogue dialogue;

        private void OnTriggerEnter(Collider other)
        {

            if (other.tag == "Player")
            {
                Debug.Log("QUIERO HABLARR!!!!");
                DialogManager.Instance.StartDialogue(dialogue);
            }
        }
    }
}
