using System;

namespace Project.Testing.ChestSM
{
    [Serializable]
    public class RopeState
    {
        protected RopeState macroState_;
        protected bool active_;
        protected bool current_;

        //properties
        public bool Active { get { return active_; } set { active_ = value; } }

        //contructor
        protected RopeState(RopeState macroState = null, bool active = true) //itself is macroState
        {
            macroState_ = null;

            active_ = true;
            current_ = false;
        }
        protected RopeState(bool active)
        {
            macroState_ = null;

            active_ = true;
            current_ = false;
        }

        //abstract methods
        public virtual void Enter(Rope rope) { current_ = true; /*Invoke(OnEnter);*/ }
        public virtual RopeState Use(Rope rope, Item item) { return null; }
        public virtual void Exit(Rope rope) { current_ = false; /*Invoke(OnExit);*/ }

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
