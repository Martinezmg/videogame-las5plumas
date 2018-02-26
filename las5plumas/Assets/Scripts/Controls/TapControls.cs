using UnityEngine;
using Project.Interactables;

namespace Project.Game
{
    public class TapControls : BaseControls
    {
        public Transform player;

        protected override void TouchUpdate(Touch touch, ref Ray touchRay)
        {
            base.TouchUpdate(touch, ref touchRay);

            RaycastHit hit;

            if (touch.phase == TouchPhase.Began)
            {
                if (RayCastTouch(touchRay.origin, touchRay.direction, out hit))  //Taps interaction
                {
                    if (touch.tapCount == 2)
                    {
                        hit.transform.GetComponent<Actioner>().TriggerSpecialAction(player);
                        return;
                    }

                    if (touch.tapCount == 1)
                    {
                        hit.transform.GetComponent<Actioner>().TriggerAction(player);
                        return;
                    }
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
