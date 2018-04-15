using System;
using System.Collections.Generic;
using UnityEngine;
using Project.Game;

namespace Project.Interactables
{
    public class ChestInteractable : Interactable
    {
        public Interactable content;

        public Animator anim;
        private int openHash = Animator.StringToHash("OpenTrigger");

        
        public void AnimationCompleted()
        {
            if (debug)
            {
                Debug.Log("Animation Completed");
            }

            if (content != null)
            {
                content.Interact();
                /*.inventory.AddItem("keys");
                Destroy(content);*/
            }
        }

        private void Start()
        {
            SM = new StateMachine(
                new List<Action> { Closed, Opened },
                Closed, 
                Opened
                );

            SM.AddTransition(Closed, ActionType.USE, Opened);

            CurrentState = SM.CurrentState.Method.Name;
        }

        private void Closed()
        {
            if (debug)
                Debug.Log(gameObject.name + " is Closed.");
        }

        private void Opened()
        {
            if (debug)
                Debug.Log(gameObject.name + " is Opened.");


            anim.SetTrigger(openHash);

        }
    }
}