using UnityEngine;
using UnityEngine.AI;

namespace Project.Game.Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerEngine : MonoBehaviour
    {
        public MovementControls motionControls;

        public NavMeshAgent agent;
        public float speed = 1;
        private float speedPercent;
        private bool isMoving = false;

        //transform from GFX
        public Transform rotation_pivot;
        private float rotationLerpSpeed = 0.35f;

        public float SpeedPercent { get { return speedPercent; } }

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            
            motionControls.E_rotateAgent   += RotateAgent;
            motionControls.E_setAgentMove  += MoveAgent;
            motionControls.E_setAgentPlane += RotatePlane;
        }

        private void Update()
        {
            if (!isMoving && speedPercent > 0)
                speedPercent = Mathf.Lerp(speedPercent, 0f, Time.deltaTime * 2 * speed);
        }

        //Motion mechanics

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

        public void IsMoving(bool m) { isMoving = m; }
    }
}
