using System;
using UnityEngine;

namespace Project.Game
{
    public class MovementControls : BaseControls
    {
        private int touch_id;
        private bool isWalking = false;
        private float move_treshold = 50f;

        public event Action         E_setAgentPlane;
        public event Action<float>  E_rotateAgent;
        public event Action<float>  E_setAgentMove;
        public event Action<bool>   E_isMoving;

        protected override void TouchUpdate(ref TouchV2 touch)
        {
            if (isWalking && touch.fingerId != touch_id)
                return;

            base.TouchUpdate(ref touch);

            if (touch.phase == TouchPhase.Began)
            {
                touch_id = touch.fingerId;
                isWalking = true;
                if (E_isMoving != null)
                    E_isMoving(isWalking);

            }

            if (touch.phase == TouchPhase.Moved)
            {
                //this is RotatePlane from PlayerMovmentEngine
                if (E_setAgentPlane != null)
                    E_setAgentPlane();

                Vector2 currentDirection = touch.position - touch.origin;

                if (currentDirection.magnitude > move_treshold)
                {
                    touch.availability = false;

                    //This is RotateAgent from PlayerMovementEngine
                    float angle = Vector2.SignedAngle(currentDirection, Vector2.up);
                    if (E_rotateAgent!=null)
                        E_rotateAgent(angle);

                    //This is MoveAgent grom PlayerMovementEngine
                    if (E_setAgentMove != null)
                        E_setAgentMove(currentDirection.magnitude/move_treshold);
                }
            }

            if (touch.phase == TouchPhase.Stationary)
            {
                if (isWalking)
                {
                    Vector2 currentDirection = touch.position - touch.origin;

                    if (currentDirection.magnitude > move_treshold)
                    {

                        //This is MoveAgent grom PlayerMovementEngine
                        if (E_setAgentMove != null)
                            E_setAgentMove(currentDirection.magnitude / move_treshold);
                    }
                }

            }

            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isWalking = false;
                if (E_isMoving != null)
                    E_isMoving(isWalking);
            }
        }

        private void LateUpdate()
        {
            if (touch0.phase == TouchPhase.Ended && touch0.fingerId == touch_id)
            {
                touch_id = 0;
                touch0.availability = true;
            }
            if (touch1.phase == TouchPhase.Ended && touch0.fingerId == touch_id)
            {
                touch_id = 0;
                touch1.availability = true;
            }
        }

    }
}
