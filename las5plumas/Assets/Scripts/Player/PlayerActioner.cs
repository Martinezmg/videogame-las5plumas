using System.Collections.Generic;
using UnityEngine;
using Project.Interactables;
using TouchScript.Gestures;

namespace Project.Game.Player
{
    public class PlayerActioner : MonoBehaviour
    {
        public TapGesture tapGesture;

        public Interactable interactableTarget = null;
        
        private List<string> CMDS { get; set; }
        public string cmd = "use";

        private void OnEnable()
        {
            tapGesture.Tapped += Action;
        }

        private void OnDisable()
        {
            tapGesture.Tapped -= Action;
        }

        public void Action(object sender, System.EventArgs e)
        {
            if (interactableTarget != null)
                interactableTarget.Interact(cmd);
        }

        private void OnTriggerEnter(Collider other)
        {
            Interactable t = other.GetComponent<Interactable>();

            if (t!=null && interactableTarget==null)
                interactableTarget = t;

            //agarrar los comandos disponibles para este objecto con el que se puede interactuar

        }

        private void OnTriggerExit(Collider other)
        {
            Interactable t = other.GetComponent<Interactable>();

            if (t != null)
                interactableTarget = null;
        }
    }
}
