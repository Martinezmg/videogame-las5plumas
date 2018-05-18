using UnityEngine;
using UnityEngine.Events;

namespace Project.Levels
{

    [RequireComponent(typeof(Collider))]
    public class EventTrigger : MonoBehaviour
    {
        public UnityEvent Event;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" && enabled)
            {
                if (Event != null)
                {
                    Event.Invoke();
                }
            }
        }
    }
}
