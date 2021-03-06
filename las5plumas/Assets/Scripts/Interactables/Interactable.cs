﻿using UnityEngine;


namespace Project.Interactables
{
    public class Interactable: MonoBehaviour
    {
        public bool debug = false;

        public string CurrentState { get; protected set; }

        protected StateMachine SM;

        public virtual void Interact(ItemAction cmd)
        {
            if (debug)
                Debug.Log("Interacted with " + gameObject.name);
            
            if (SM.MoveNext(cmd))
            {
                SM.CurrentState();
                CurrentState = SM.CurrentState.Method.Name;
            }
        }

        public virtual void Interact()
        {
            if (debug)
                Debug.Log("Interacted with " + gameObject.name);
        }
    }
}
