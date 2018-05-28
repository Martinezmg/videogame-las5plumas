using UnityEngine;
using UnityEngine.Events;

namespace Project.Game
{
    public class AhkitobeTeletransport : MonoBehaviour
    {
        public Transform target;
        public Transform destination;

        public UnityEvent OnTP;

        public void TeletransportTarget()
        {
            target.gameObject.SetActive(false);
            target.position = destination.position;
            target.gameObject.SetActive(true);

            OnTP.Invoke();
        }
    }
}
