using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Project.Levels;

namespace Project.Interactables
{
    [RequireComponent(typeof(NavMeshObstacle))]
    [RequireComponent(typeof(Animator))]
    public class GateInteractable : Interactable
    {
        public NavMeshObstacle obstacle;
        public Animator anim;
        private int openHash = Animator.StringToHash("OpenTrigger");

        public void AnimationCompleted()
        {
            if (debug)
            {
                Debug.Log(name + " animation completed.");
            }

            obstacle.enabled = false;
        }

        // Use this for initialization
        void Start()
        {
            if(obstacle==null)
                obstacle = GetComponent<NavMeshObstacle>();
            if (anim == null)
                anim = GetComponent<Animator>();

            SM = new StateMachine(
                new List<Action> {
                    Locked,
                    Opened
                },
                Locked,
                Opened
                );

            SM.AddTransition(Locked, ItemAction.OPEN, Opened);

            CurrentState = SM.CurrentState.Method.Name;

        }

        private void Opened()
        {
            if (debug)
                Debug.Log(gameObject.name + " is Opened.");

            anim.SetTrigger(openHash);
        }

        private void Locked()
        {
            throw new NotImplementedException();
        }

        public override void Interact(ItemAction cmd)
        {
            base.Interact(cmd);

            //ojo cambiar esto
            if (TheBlackLagoon.Instance.key == null)
                base.Interact(ItemAction.OPEN);
        }
    }
}