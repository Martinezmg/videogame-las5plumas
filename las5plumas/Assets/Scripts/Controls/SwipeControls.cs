using System;
using UnityEngine;

namespace Project.Game
{
    enum Swipe { left, rigth, up, down, none };

    public class SwipeControls : BaseControls
    {
        private int touch_id;

        private float angle;
        private float minDistance = 10f;
        private float time;

        private float time_treshold = 1f;
        private float swipeDistance_treshold = 2f;

        public event Action<int> E_swipe;

        public bool debug = false;

        private void Start()
        {
            if (debug)
                E_swipe += Test_swipe;
        }

        protected override void TouchUpdate(ref TouchV2 touch)
        {
            if (touch.Phase == TouchPhase.Began)
            {
                if (!touch.availability || touch_id != 0)
                    return;

                touch_id = touch.FingerId;
                time = Time.time;
            }
            else if (touch.Phase == TouchPhase.Canceled && touch.FingerId == touch_id)
            {
                Reset();
            }
            else if (touch.Phase == TouchPhase.Ended && touch.FingerId == touch_id)
            {
                Vector2 v = touch.Position - touch.origin;

                if (v.magnitude < minDistance || Time.time - time > time_treshold)
                {
                    Reset();
                    return;
                }

                float x = v.x;
                float y = v.y;
                

                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    if (x < 0)
                    {
                        if (E_swipe != null)
                            E_swipe((int)Swipe.rigth);
                    }

                    else
                    {
                        if (E_swipe != null)
                            E_swipe((int)Swipe.left);
                    }
                }
                else
                {
                    if (y < 0)
                    {
                        if (E_swipe != null)
                            E_swipe((int)Swipe.down);
                    }
                    else
                    {
                        if (E_swipe != null)
                            E_swipe((int)Swipe.up);
                    }
                }
            }
            else
            {
                if (touch.FingerId != touch_id)
                    return;

                if (touch.Position == touch.origin)
                {
                    angle = Vector2.SignedAngle(touch.Position - touch.origin, Vector2.zero);
                    return;
                }
                
                float deltaAngle = Vector2.SignedAngle(touch.touch.deltaPosition, Vector2.zero);

                if (Mathf.Abs(deltaAngle) > Mathf.Abs(angle) * swipeDistance_treshold)
                {
                    Reset();
                    return;
                }
            }
        }

        private void Reset()
        {
            angle = 0;
            touch_id = 0;
        }

        private void Test_swipe(int s) { Debug.Log("Swipe to " + (Swipe)s); }
    }
}
