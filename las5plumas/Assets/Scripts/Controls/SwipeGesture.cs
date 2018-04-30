using UnityEngine;
using TouchScript.Gestures;
using System;

namespace Project.Game
{
    [RequireComponent(typeof(FlickGesture))]
    public class SwipeGesture : MonoBehaviour
    {
        FlickGesture baseGesture;

        public event Action SwipeUp;
        public event Action SwipeDown;
        public event Action SwipeLeft;
        public event Action SwipeRigth;

        private void Awake()
        {
            baseGesture = GetComponent<FlickGesture>();
        }

        private void OnEnable()
        {
            baseGesture.Flicked += SwipeHandler;
        }

        private void OnDisable()
        {
            baseGesture.Flicked -= SwipeHandler;
        }

        private void SwipeHandler(object sender, EventArgs e)
        {
            Vector2 v = baseGesture.ScreenFlickVector;

            float x = v.x;
            float y = v.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                {
                    if (SwipeRigth != null)
                        SwipeRigth();
                }                    
                else
                {
                    if (SwipeLeft != null)
                        SwipeLeft();
                }
            }
            else
            {
                if (y < 0)
                {
                    if (SwipeDown != null)
                        SwipeDown();
                }
                else
                {
                    if (SwipeUp != null)
                        SwipeUp();
                }
            }
        }
    }
}
