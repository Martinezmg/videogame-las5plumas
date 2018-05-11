using System;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Testing
{
    //[Serializable]
    public class GateState
    {

        protected GateState macroState_;
        protected bool active_;
        protected bool current_;

        //properties
        public bool Active { get { return active_; } set { active_ = value; } }

        //contructor
        protected GateState(GateState macroState = null, bool active = true, bool current = false)
        {
            macroState_ = macroState;

            active_ = active;
            current_ = current;
        }

        //abstract methods
        public virtual void Enter(Gate gate) { current_ = true; }
        public virtual GateState Use(Gate gate, Item item) { return null; }
        public virtual void Exit(Gate gate) { current_ = false; }

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
