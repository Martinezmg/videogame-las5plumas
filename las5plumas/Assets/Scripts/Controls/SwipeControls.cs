using UnityEngine;
using UnityEngine.Events;

namespace Project.Game
{
    enum Swipe { left, rigth, up, down, none };

    [System.Serializable]
    public class SwipeEvent : UnityEvent<int> {}

    public class SwipeControls : BaseControls
    {
        private bool swipeLeft, swipeRight, swipeUp, swipeDown, forceCancel = false;

        private Vector2 origin;
        private Vector2 current;
        private Vector2 delta;

        private float angle;
        private float minDistance = 10f;
        private float time;

        private float time_treshold = 1f;
        private float swipeDistance_treshold = 1.25f;

        public SwipeEvent e_swipe;

        private void Start()
        {
            if (e_swipe == null)
                e_swipe = new SwipeEvent();
        }

        protected override void TouchUpdate(ref TouchV2 touch)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Reset();

                time = Time.time;
                origin = touch.position;
                current = touch.position;
            }
            else if (touch.phase == TouchPhase.Canceled)
            {
                forceCancel = true;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                if (forceCancel)
                    return;

                Vector2 v = current - origin;

                if (v.magnitude < minDistance || Time.time - time > time_treshold)
                    return;

                float x = v.x;
                float y = v.y;

                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    if (x < 0)
                    {
                        if (e_swipe != null)
                            e_swipe.Invoke((int)Swipe.rigth);
                    }

                    else
                    {
                        if (e_swipe != null)
                            e_swipe.Invoke((int)Swipe.left);
                    }
                }
                else
                {
                    if (y < 0)
                    {
                        if (e_swipe != null)
                            e_swipe.Invoke((int)Swipe.down);
                    }
                    else
                    {
                        if (e_swipe != null)
                            e_swipe.Invoke((int)Swipe.up);
                    }
                }
            }
            else
            {
                if (forceCancel)
                    return;

                if (current == origin)
                {
                    current = touch.position;
                    angle = Vector2.SignedAngle(current - origin, Vector2.zero);
                    return;
                }

                delta = touch.position - current;
                float deltaAngle = Vector2.SignedAngle(delta, Vector2.zero);

                if (Mathf.Abs(deltaAngle) > Mathf.Abs(angle) * swipeDistance_treshold)
                {
                    forceCancel = true;

                    return;
                }

                current = touch.position;
            }
        }

        private void Reset()
        {
            origin = current = delta = Vector2.zero;
            angle = 0;
            swipeLeft = swipeRight = swipeUp = swipeDown = forceCancel = false;
        }
    }
}
