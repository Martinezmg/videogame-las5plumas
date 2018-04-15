using UnityEngine;


namespace Project.Game
{
    [RequireComponent(typeof(AhkitobeEngine))]
    public class AhkitobeAnimController : MonoBehaviour
    {
        const float locomotionAnimSmoothTime = 0.1f;

        public AhkitobeEngine motor;
        public Animator animator;

        // Use this for initialization
        void Start()
        {
            motor = GetComponent<AhkitobeEngine>();
        }

        // Update is called once per frame
        void Update()
        {
            animator.SetFloat("speedPercent", motor.agent.velocity.magnitude, locomotionAnimSmoothTime, Time.deltaTime);
        }
    }
}
