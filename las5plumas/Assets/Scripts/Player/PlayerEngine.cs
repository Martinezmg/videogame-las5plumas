using UnityEngine;
using UnityEngine.AI;
using TouchScript.Gestures;
using Project.GUI;
using System;

namespace Project.Game.Player
{
    using GestureState = TouchScript.Gestures.Gesture.GestureState;

    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerEngine : MonoBehaviour, IManager
    {
        //touchscript
        public TapGesture tapGesture;
        public Vector2 startScreenPosition;
        public float movementTreshold;
        public GestureState gestureState;

        public NavMeshAgent agent;
        public float speed = 1;
        private float speedPercent;
        private bool isMoving = false;

        //transform from GFX
        public Transform rotation_pivot;
        private float rotationLerpSpeed = 0.35f;

        public float SpeedPercent { get { return speedPercent; } }
        public Vector2 StartScreenPosition { get { return startScreenPosition; } }
        public bool IsMoving { get { return isMoving; } }


        #region Unity
        private void Awake()
        {
            MainManager.Instance.stopGesturesFromGame += DisableComponent;
            MainManager.Instance.playGesturesFromGame += EnableComponent;

            tapGesture = MainManager.Instance.holdtapGesture;
        }

        private void OnEnable()
        {
            tapGesture.StateChanged += UpdateMovement;
            tapGesture.Tapped += ResetMovement;
        }

        private void OnDisable()
        {
            tapGesture.StateChanged -= UpdateMovement;
            tapGesture.Tapped -= ResetMovement;
        }

        private void Start()
        {
            

            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            gestureState = tapGesture.State;

            if (isMoving)
            {
                RotatePlane();

                Vector2 currentDirection = tapGesture.ScreenPosition - startScreenPosition;
                
                if (currentDirection.magnitude > movementTreshold)
                {
                    float angle = Vector2.SignedAngle(currentDirection, Vector2.up);
                    float s = currentDirection.magnitude;


                    GUIManager.instance.UpdateIndicator(angle);

                    RotateAgent(angle);
                    MoveAgent(s / (s + movementTreshold));
                }
            }

            if (!isMoving && speedPercent > 0)
                speedPercent = Mathf.Lerp(speedPercent, 0f, Time.deltaTime * 2 * speed);
        }
        #endregion
        
        #region TouchScript
        private void UpdateMovement(object sender, EventArgs e)
        {
            if (tapGesture.State == GestureState.Possible)
            {
                isMoving = true;
                startScreenPosition = tapGesture.ScreenPosition;

                GUIManager.instance.SetIndicator(startScreenPosition);
            }
            if (tapGesture.State == GestureState.Failed)
            {
                isMoving = false;

                GUIManager.instance.UnsetIndicator();
            }
        }

        private void ResetMovement(object sender, EventArgs e)
        {
            isMoving = false;

            GUIManager.instance.UnsetIndicator();
        }

        #endregion

        #region Motion Mechanics

        public void RotatePlane()
        {
            transform.eulerAngles = Vector3.Lerp(
                            transform.eulerAngles,
                            new Vector3(
                                transform.eulerAngles.x,
                                Camera.main.transform.eulerAngles.y,
                                transform.eulerAngles.z),
                                Time.deltaTime);
        }

        public void RotateAgent(float angle)
        {
            Quaternion rotateTo = Quaternion.Euler(
                            rotation_pivot.eulerAngles.x,
                            angle + Camera.main.transform.eulerAngles.y,
                            rotation_pivot.eulerAngles.z);

            rotation_pivot.rotation = Quaternion.Lerp(
                rotation_pivot.rotation,
                rotateTo,
                rotationLerpSpeed);
        }

        public void MoveAgent(float s)
        {
            speedPercent = Mathf.Clamp01(s);
            agent.Move(rotation_pivot.forward * Time.deltaTime * speed);
        }
        
        #endregion

        public void DisableComponent()
        {
            enabled = false;
        }

        public void EnableComponent()
        {
            enabled = true;
        }
    }
}
