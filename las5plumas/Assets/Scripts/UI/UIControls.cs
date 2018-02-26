using System;
using UnityEngine;

namespace Project.Game.UI
{
    public enum Swipe { left, rigth, up, down, none };

    public class UIControls : MonoBehaviour
    {

        public bool swipeLeft, swipeRight, swipeUp, swipeDown, forceCancel = false;
        public Swipe swipe = Swipe.none;
        private Vector2 origin;
        private Vector2 current;
        private Vector2 delta;
        private float angle;
        private float minDistance = 10f;
        private float time;

        public string debug = "";

        public Controls mainControls;
        public GameObject defaulPanel;
        public event Action<Swipe> UIUpdate;

        private void Update()
        {

            if (Input.touchCount > 0)
            {
                debug = Input.touches[0].phase.ToString();

                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    Reset();

                    time = Time.time;
                    origin = Input.touches[0].position;
                    current = Input.touches[0].position;
                }
                else if (Input.touches[0].phase == TouchPhase.Canceled )
                {
                    forceCancel = true;
                    Debug.Log("Called by canceled or stationary");
                }
                else if (Input.touches[0].phase == TouchPhase.Ended)
                {
                    if (forceCancel)
                        return;

                    Vector2 v = current - origin;

                    if (v.magnitude < minDistance || Time.time - time > 1f)
                        return;


                    float x = v.x;
                    float y = v.y;

                    if (Mathf.Abs(x) > Mathf.Abs(y))
                    {
                        if (x < 0 && UIUpdate != null)
                            UIUpdate(Swipe.rigth);
                        else
                            if (UIUpdate != null)
                                UIUpdate(Swipe.left);
                    }
                    else
                    {
                        if (y < 0 && UIUpdate != null)
                            UIUpdate(Swipe.down);
                        else
                            if (UIUpdate != null)
                                UIUpdate(Swipe.up);
                    }
                }
                else
                {
                    if (forceCancel)
                        return;

                    if (current == origin)
                    {
                        current = Input.touches[0].position;
                        angle = Vector2.SignedAngle(current - origin, Vector2.zero);
                        return;
                    }

                    delta = Input.touches[0].position - current;
                    float deltaAngle = Vector2.SignedAngle(delta, Vector2.zero);

                    if (Mathf.Abs(deltaAngle) > Mathf.Abs(angle) * 1.25f) // este valor deberia ser el cambio minimo para salir de algun limite
                    {
                        forceCancel = true;

                        Debug.Log("Called by angle");
                        return;
                    }

                    current = Input.touches[0].position;
                }
            }
        }

        private void Reset()
        {
            origin = current = delta = Vector2.zero;
            angle = 0;
            swipeLeft = swipeRight = swipeUp = swipeDown = forceCancel = false;
        }

        public void ResetUI()
        {
            foreach (Transform panel in GetComponentInChildren<Transform>())
                panel.gameObject.SetActive(false);

            defaulPanel.SetActive(true);
        }

        private void OnEnable()
        {
            mainControls.enabled = false;
        }

        private void OnDisable()
        {
            mainControls.enabled = true;

            ResetUI();
            gameObject.SetActive(false);
        }
    }
}
