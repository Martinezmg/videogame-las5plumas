using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Testing
{
    [Serializable]
    public class BaseState
    {
        //att
        [SerializeField]
        protected UnityEvent OnEnter;
        [SerializeField]
        protected UnityEvent OnUse;
        [SerializeField]
        protected UnityEvent OnExit;

        BaseState macroState_;

        protected bool active_;
        protected bool current_;

        //properties
        public bool Active { get { return active_; } set { active_ = value; } }

        //contructor
        protected BaseState(BaseState macroState = null, bool active = true) //itself is macroState
        {
            macroState_ = null;

            active_ = true;
            current_ = false;
        }

        //abstract methods
        public virtual void Enter(Interactable gate) { current_ = true; OnEnter.Invoke(); }
        public virtual BaseState Use(Interactable gate, Item item) { return null; }
        public virtual void Exit(Interactable gate) { current_ = false; OnExit.Invoke(); }


        protected bool CanUse()
        {
            if (macroState_ != null)
            {
                return active_ && macroState_.current_;
            }

            return active_;
        }
    }
}
