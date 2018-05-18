using UnityEngine;
using Project.Game;
using TouchScript.Gestures;

namespace Project.Testing
{
    public class Player : MonoBehaviour, IManager
    {
        public bool resetItem = false;

        public TapGesture tapGesture;

        public Interactable interactableTarget = null;

        public PlayersItem itemContainer;
        

        private void Start()
        {
            tapGesture = MainManager.Instance.tapGesture;
            tapGesture.Tapped += Action;

            MainManager.Instance.playGesturesFromGame += EnableComponent;
            MainManager.Instance.stopGesturesFromGame += DisableComponent;

            name = "Player";

            itemContainer.ItemContainer = null;
        }

        private void OnEnable()
        {
            if (tapGesture != null)
                tapGesture.Tapped += Action;
            //item = InventoryManager.Instance.selector.
        }

        private void OnDisable()
        {
            tapGesture.Tapped -= Action;
        }

        public void Action(object sender, System.EventArgs e)
        {
            if (interactableTarget != null)
            {
                if (itemContainer.ItemContainer != null && itemContainer.ItemContainer.Available)
                    interactableTarget.Use(itemContainer.ItemContainer.item_);
                else
                    interactableTarget.Use(null);
            } 
        }

        private void OnTriggerEnter(Collider other)
        {
            Interactable t = other.GetComponent<Interactable>();

            if (t != null && interactableTarget == null)
            {
                interactableTarget = t;
                interactableTarget.Touch();
            }

        }

        private void OnTriggerExit(Collider other)
        {
            Interactable t = other.GetComponent<Interactable>();

            if (t != null)
                interactableTarget = null;
        }

        public void DisableComponent()
        {
            enabled = false;
        }

        public void EnableComponent()
        {
            enabled = true;
        }
    }
}