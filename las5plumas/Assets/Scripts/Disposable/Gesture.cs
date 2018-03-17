using UnityEngine;
using UnityEngine.Events;

namespace Project.Game
{

    public class Gesture : MonoBehaviour
    {
        public UnityEvent @event;

        // Use this for initialization
        void Start()
        {
            if (@event == null)
            {
                @event = new UnityEvent();
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}