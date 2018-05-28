using UnityEngine;
using UnityEngine.Events;

namespace Project.Levels
{

    [RequireComponent(typeof(Collider))]
    public class EventTrigger : MonoBehaviour
    {
        public GameObject activator;

        public UnityEvent Event;

        [Header("Debug")]
        public string debugText = "";

        private void OnTriggerEnter(Collider other)
        {
            if ((other.tag == "Player" || (activator != null && activator == other.gameObject)) && enabled)
            {
                if (Event != null)
                {
                    Event.Invoke();
                }
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (activator != null && activator == collision.gameObject && enabled)
            {
                if (Event != null)
                {
                    Event.Invoke();
                }
            }
        }

        public void DebugCallBack()
        {
            Debug.Log(debugText);
        }
    }
}
