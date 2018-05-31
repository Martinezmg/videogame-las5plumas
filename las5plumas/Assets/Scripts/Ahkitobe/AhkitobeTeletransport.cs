using UnityEngine;
using UnityEngine.Events;

namespace Project.Game
{
    public class AhkitobeTeletransport : MonoBehaviour
    {
        public Transform target;
        public Transform destination;

        public UnityEvent OnTP;

        private bool active = true;

        public bool Active
        {
            get
            {
                return active;
            }

            set
            {
                active = value;
            }
        }

        public void TeletransportTarget()
        {
            if (!Active)
                return;

            target.gameObject.SetActive(false);
            target.position = destination.position;
            target.gameObject.SetActive(true);

            OnTP.Invoke();
        }
    }
}
