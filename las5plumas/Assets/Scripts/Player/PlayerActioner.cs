using UnityEngine;
using Project.Interactables;
using TouchScript.Gestures;

namespace Project.Game.Player
{
    public class PlayerActioner : MonoBehaviour, IManager
    {
        public TapGesture tapGesture;

        public Interactable interactableTarget = null;
        
        public static ItemAction defaultAction = ItemAction.USE;
        [SerializeField]
        private ItemAction currentAction;
        public ItemAction CurrentAction { get { return currentAction; } set { currentAction = value; } }


        private void OnEnable()
        {
            tapGesture.Tapped += Action;
        }

        private void OnDisable()
        {
            tapGesture.Tapped -= Action;
        }

        private void Awake()
        {
            tapGesture = MainManager.Instance.tapGesture;

            currentAction = defaultAction;
        }

        private void Start()
        {
            MainManager.Instance.playGesturesFromGame += EnableComponent;
            MainManager.Instance.stopGesturesFromGame += DisableComponent;
        }

        public void Action(object sender, System.EventArgs e)
        {
            if (interactableTarget != null)
                interactableTarget.Interact(currentAction);
        }

        private void OnTriggerEnter(Collider other)
        {
            Interactable t = other.GetComponent<Interactable>();

            if (t!=null && interactableTarget == null)
            {
                interactableTarget = t;
                interactableTarget.Interact();
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
