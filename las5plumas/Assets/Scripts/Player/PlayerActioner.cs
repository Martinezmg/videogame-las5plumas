using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Interactables;

namespace Project.Game.Player
{
    public class PlayerActioner : MonoBehaviour
    {
        public TapControls tapControls;

        Interactable interactableTarget = null;

        private void Start()
        {
            tapControls.E_tap += Action;
        }

        public void Action()
        {
            if (interactableTarget != null)
                interactableTarget.Interact();


        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Entro en el colider de " + collision.gameObject.name);

            if (interactableTarget != null)
                return;

            interactableTarget = collision.gameObject.GetComponent<Interactable>();
        }

        private void OnCollisionExit(Collision collision)
        {
            interactableTarget = null;
        }
        
    }
}
