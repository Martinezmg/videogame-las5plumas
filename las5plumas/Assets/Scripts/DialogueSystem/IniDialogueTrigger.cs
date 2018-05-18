using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Game;

namespace Project.DialogueSystem
{
    public class IniDialogueTrigger : MonoBehaviour, IManager
    {
        
        public Dialogue dialogue;

        public Transform nextPoint;
        public AhkitobeEngine ahkitobe;

        private void Awake()
        {
            MainManager.Instance.GetComponent<Fading>().FadeFinished += EnableComponent;
            DialogManager.Instance.DialogEnd += AhkNextPoint;
        }

        private void OnDisable()
        {
            MainManager.Instance.GetComponent<Fading>().FadeFinished -= EnableComponent;
        }

        public void DisableComponent()
        {
            enabled = false;
        }

        public void EnableComponent()
        {
            enabled = true;
        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.tag == "Player")
            {
                DialogManager.Instance.StartDialogue(dialogue);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                Destroy(gameObject);
            }
        }

        private void AhkNextPoint(Dialogue obj)
        {
            if (obj.name != dialogue.name)
            {
                return;
            }

            ahkitobe.agent.SetDestination(nextPoint.position);
            ahkitobe.dialogPop.SetActive(false);
        }
    }
}
