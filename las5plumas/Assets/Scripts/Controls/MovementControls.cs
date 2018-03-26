using System;
using UnityEngine;

namespace Project.Game
{
    public class MovementControls : BaseControls
    {
        private int touch_id;
        private bool isWalking = false;
        [SerializeField]
        private float move_treshold = 150f;

        public event Action         E_setAgentPlane;
        public event Action<float>  E_rotateAgent;
        public event Action<float>  E_setAgentMove;
        public event Action<bool>   E_isMoving;

        protected override void TouchUpdate(ref TouchV2 touch)
        {
            if (isWalking && touch.FingerId != touch_id)
                return;

            base.TouchUpdate(ref touch);

            if (touch.Phase == TouchPhase.Began)
            {
                touch_id = touch.FingerId;
                isWalking = true;
                if (E_isMoving != null)
                    E_isMoving(isWalking);

            }

            if (touch.Phase == TouchPhase.Moved)
            {
                //this is RotatePlane from PlayerMovmentEngine
                if (E_setAgentPlane != null)
                    E_setAgentPlane();

                Vector2 currentDirection = touch.Position - touch.origin;

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

            if (touch.Phase == TouchPhase.Stationary)
            {
                if (isWalking)
                {
                    Vector2 currentDirection = touch.Position - touch.origin;

                    if (currentDirection.magnitude > move_treshold)
                    {

                        //This is MoveAgent grom PlayerMovementEngine
                        if (E_setAgentMove != null)
                            E_setAgentMove(currentDirection.magnitude / move_treshold);
                    }
                }

            }

            if (touch.Phase == TouchPhase.Ended || touch.Phase == TouchPhase.Canceled)
            {
                isWalking = false;
                if (E_isMoving != null)
                    E_isMoving(isWalking);
            }
        }

        private void LateUpdate()
        {
            if (touch0.Phase == TouchPhase.Ended && touch0.FingerId == touch_id)
            {
                touch_id = 0;
                touch0.availability = true;
            }
            if (touch1.Phase == TouchPhase.Ended && touch0.FingerId == touch_id)
            {
                touch_id = 0;
                touch1.availability = true;
            }
        }

    }
}
