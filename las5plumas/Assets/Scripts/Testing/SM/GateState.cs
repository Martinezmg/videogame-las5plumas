using System;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Testing
{
    [Serializable]
    public class GateState
    {
        //att
        [SerializeField]
        protected UnityEvent OnEnter;
        [SerializeField]
        protected UnityEvent OnUse;
        [SerializeField]
        protected UnityEvent OnExit;

        protected GateState macroState_;
        protected bool active_;
        protected bool current_;

        //properties
        public bool Active { get { return active_; } set { active_ = value; } }

        //contructor
        protected GateState(GateState macroState = null, bool active = true) //itself is macroState
        {
            macroState_ = null;

            active_ = true;
            current_ = false;
        }
        protected GateState(bool active)
        {
            macroState_ = null;

            active_ = true;
            current_ = false;
        }

        //abstract methods
        public virtual void Enter(Gate gate) { current_ = true; OnEnter.Invoke(); }
        public virtual GateState Use(Gate gate, Item item) { return null; }
        public virtual void Exit(Gate gate) { current_ = false; OnExit.Invoke(); }

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
