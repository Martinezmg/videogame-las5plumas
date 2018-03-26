using UnityEngine;
using UnityEngine.AI;

namespace Project.Game.Player
{

    [RequireComponent(typeof(PlayerEngine))]
    public class PlayerAniController : MonoBehaviour
    {

        const float locomotionAnimSmoothTime = 0.1f;

        public PlayerEngine motor;
        public Animator animator;
        //private Transform gfx;

        // Use this for initialization
        void Start()
        {
            motor = GetComponent<PlayerEngine>();
            //gfx = animator.GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {
            animator.SetFloat("speedPercent", motor.SpeedPercent, locomotionAnimSmoothTime, Time.deltaTime);
            
        }
    }
}
