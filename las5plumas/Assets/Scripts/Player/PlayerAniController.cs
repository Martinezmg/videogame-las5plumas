using System.Collections;
using UnityEngine;

namespace Project.Game.Player
{
    [RequireComponent(typeof(PlayerEngine))]
    public class PlayerAniController : MonoBehaviour
    {
        const float locomotionAnimSmoothTime = 0.1f;

        public PlayerEngine motor;
        public Animator animator;

        public AudioSource cuatro;

        private IEnumerator Timer_COURUTINE;
        private const float idleTime = 5f;

        private IEnumerator IdleTimer()
        {
            //wait idleTime seconds until start idle animation
            yield return new WaitForSeconds(idleTime);

            //animator.SetBool("idle", true);
        }

        // Use this for initialization
        void Start()
        {
            motor = GetComponent<PlayerEngine>();
        }

        // Update is called once per frame
        void Update()
        {
            float speed = motor.SpeedPercent;

            //esto seguro puede programarse dentro de los estados del animator
            if (animator.GetCurrentAnimatorStateInfo(0).shortNameHash == Animator.StringToHash("Motion"))
            {
                motor.canMove = true;
            }
            else
            {
                motor.canMove = false;

                if (animator.GetCurrentAnimatorStateInfo(0).shortNameHash == Animator.StringToHash("cuatro"))
                {
                    if(!cuatro.isPlaying)
                        cuatro.Play();
                }
                else
                {
                    if(cuatro.isPlaying)
                        cuatro.Stop();
                }
            }


            if (motor.canMove)
                animator.SetFloat("speedPercent", speed, locomotionAnimSmoothTime, Time.deltaTime);

            if (Mathf.Abs(speed) < 0.005f)
            {
                //start timer for play cuatro
                if (Timer_COURUTINE == null)
                {
                    Timer_COURUTINE = IdleTimer();
                    StartCoroutine(Timer_COURUTINE);
                }

                
            }
            else
            {
                if (Timer_COURUTINE != null)
                {
                    StopCoroutine(Timer_COURUTINE);
                    Timer_COURUTINE = null;
                }

                if (animator.GetBool("idle"))
                {
                    animator.SetBool("idle", false);
                }
                //stop timer for play cuatro or idle false
            }


        }


    }
}
