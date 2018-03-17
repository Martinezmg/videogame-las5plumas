using UnityEngine;
using UnityEngine.Events;

namespace Project.Game
{
    [System.Serializable]
    public class RotateAgentEvent : UnityEvent<float> { }

    public class MovementControls : BaseControls
    {
        private Vector2 origin_point;
        private int touch_id;
        private bool isWalking = false;
        private float move_treshold = 50f;

        public UnityEvent e_setAgentPlane;
        public RotateAgentEvent e_rotateAgent;
        public UnityEvent e_setAgentMove;

        private void Start()
        {
            if (e_setAgentPlane == null)
                e_setAgentPlane = new UnityEvent();

            if (e_rotateAgent == null)
                e_rotateAgent = new RotateAgentEvent();

            if (e_setAgentMove == null)
                e_setAgentMove = new UnityEvent();
        }

        protected override void TouchUpdate(ref TouchV2 touch)
        {
            if (isWalking && touch.fingerId != touch_id)
                return;
            
            if (touch.phase == TouchPhase.Began)
            {
                origin_point = touch.position;
                touch_id = touch.fingerId;
                isWalking = true;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                //this is RotatePlane from PlayerMovmentEngine
                if (e_setAgentPlane != null)
                    e_setAgentPlane.Invoke();

                Vector2 currentDirection = touch.position - origin_point;

                if (currentDirection.magnitude > move_treshold)
                {
                    float angle = Vector2.SignedAngle(currentDirection, Vector2.up);

                    //This is RotateAgent from PlayerMovementEngine
                    if (e_rotateAgent != null)
                        e_rotateAgent.Invoke(angle);

                    //This is MoveAgent grom PlayerMovementEngine
                    if (e_setAgentMove != null)
                        e_setAgentMove.Invoke();
                }
            }

            if (touch.phase == TouchPhase.Stationary)
            {
                if (isWalking)
                {
                    Vector2 currentDirection = touch.position - origin_point;

                    if (currentDirection.magnitude > move_treshold)
                    {

                        //This is MoveAgent grom PlayerMovementEngine
                        if (e_setAgentMove != null)
                            e_setAgentMove.Invoke();
                    }
                }

            }

            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isWalking = false;
                origin_point = Vector2.zero;
                touch_id = 0;
            }
        }

    }
}
