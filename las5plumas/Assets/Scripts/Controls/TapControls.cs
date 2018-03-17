using UnityEngine;
using UnityEngine.Events;

namespace Project.Game
{
    [System.Serializable]
    public class FocusGameObject : UnityEvent<Collider> { }

    public class TapControls : BaseControls
    {
        public FocusGameObject e_focusGameObject;
        public UnityEvent e_tap;
        public UnityEvent e_taptap;

        private void Start()
        {
            if (e_focusGameObject == null)
                e_focusGameObject = new FocusGameObject();

            if (e_tap == null)
                e_tap = new UnityEvent();

            if (e_taptap == null)
                e_taptap = new UnityEvent();
        }

        protected override void TouchUpdate(ref TouchV2 touch, ref Ray touchRay)
        {
            base.TouchUpdate(ref touch, ref touchRay);

            RaycastHit hit;

            if (touch.phase == TouchPhase.Began)
            {
                if (touch.tapCount == 1)
                {
                    if (RayCastTouch(touchRay.origin, touchRay.direction, out hit))  //Taps interaction
                    {
                        //turn to object hit
                        if (e_focusGameObject != null)
                            e_focusGameObject.Invoke(hit.collider);
                    }

                    //invoque tap event
                    if (e_tap != null)
                        e_tap.Invoke();
                }

                if (touch.tapCount == 2)
                {
                    //invoque taptap event
                    if (e_taptap != null)
                        e_taptap.Invoke();
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
    }
}
