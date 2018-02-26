using System;
using UnityEngine;

namespace Project.Game
{
    enum Swipe { left, rigth, up, down, none };

    public class SwipeControls : BaseControls
    {
        public bool swipeLeft, swipeRight, swipeUp, swipeDown, forceCancel = false;
        Swipe swipe = Swipe.none;

        private Vector2 origin;
        private Vector2 current;
        private Vector2 delta;

        private float angle;
        private float minDistance = 10f;
        private float time;

        private float time_treshold = 1f;
        private float swipeDistance_treshold = 1.25f;

        event Action<Swipe> UIUpdate;
        event Action<Swipe> GameUpdate;

        private bool internalBlock0 = false;
        private bool internalBlock1 = false;

        protected override void TouchUpdate(Touch touch, ref Ray touchRay)
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
                Debug.Log("Called by canceled or stationary");
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
                        if (GameState == GameState.paused && UIUpdate != null)
                            UIUpdate(Swipe.rigth);
                        if (GameState == GameState.running && GameUpdate != null)
                            GameUpdate(Swipe.rigth);
                    }

                    else
                    {
                        if (GameState == GameState.paused && UIUpdate != null)
                            UIUpdate(Swipe.left);
                        if (GameState == GameState.running && GameUpdate != null)
                            GameUpdate(Swipe.left);
                    }
                }
                else
                {
                    if (y < 0)
                    {
                        if (GameState == GameState.paused && UIUpdate != null)
                            UIUpdate(Swipe.down);
                        if (GameState == GameState.running && GameUpdate != null)
                            GameUpdate(Swipe.down);
                    }
                    else
                    {
                        if (GameState == GameState.paused && UIUpdate != null)
                            UIUpdate(Swipe.up);
                        if (GameState == GameState.running && GameUpdate != null)
                            GameUpdate(Swipe.up);
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

                    Debug.Log("Called by angle");
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
