using System;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Game
{
    public class TapControls : BaseControls
    {

        private Vector2 origin;

        public event Action<Collider> E_focusGameObject;
        public event Action E_tap;
        public event Action E_taptap;

        public bool debug = false;

        private void Start()
        {
            if (debug)
            {
                E_focusGameObject += Test_focus;
                E_tap += Test_tap;
                E_taptap += Test_taptap;
            }
        }

        protected override void TouchUpdate(ref TouchV2 touch, ref Ray touchRay)
        {
            if (!touch.availability)
                return;

            base.TouchUpdate(ref touch, ref touchRay);

            if (touch.phase == TouchPhase.Began)
            {
                origin = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                float magnitude = (touch.position - origin).magnitude;

                if (magnitude > 5f)
                    return;

                if (touch.tapCount == 1)
                {
                    RaycastHit hit;

                    if (RayCastTouch(touchRay.origin, touchRay.direction, out hit))  //Taps interaction
                    {
                        //turn to object hit
                        if (E_focusGameObject != null)
                            E_focusGameObject(hit.collider);
                    }

                    //invoque tap event
                    if (E_tap != null)
                        E_tap();
                }

                if (touch.tapCount == 2)
                {
                    //invoque taptap event
                    if (E_taptap != null)
                        E_taptap();
                }
            }
        }

        private bool RayCastTouch(Vector3 origin, Vector3 direction, out RaycastHit objectHit)
        {
            return Physics.Raycast(
                       origin,        //origin
                       direction,     //direction
                       out objectHit, //out info
                       2000f,         //max length
                       LayerMask.GetMask("Interactable"),  //layer mask 
                       QueryTriggerInteraction.UseGlobal);  //Trigger interaction
        }

        private void Test_tap() { Debug.Log("TAP!"); }
        private void Test_taptap() { Debug.Log("TAPTAP!"); }
        private void Test_focus(Collider c) { Debug.Log("FOCUS " + c.name); }
    }

}
