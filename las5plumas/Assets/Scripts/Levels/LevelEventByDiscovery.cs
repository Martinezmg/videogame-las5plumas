using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Levels
{

    public class LevelEventByDiscovery : MonoBehaviour
    {
        public UnityEvent LevelEvent;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                LevelEvent.Invoke();
            }
        }
    }
}
