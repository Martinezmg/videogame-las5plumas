using UnityEngine;
using UnityEngine.Events;

namespace Project.Levels
{
    [RequireComponent(typeof(Collider))]
    public class EventTriggerBy : MonoBehaviour
    {
        public GameObject activator;

        public UnityEvent Event;

        [Header("Debug")]
        public string debugText = "";

        private void OnTriggerEnter(Collider other)
        {
            if (activator != null && activator == other.gameObject && enabled)
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
