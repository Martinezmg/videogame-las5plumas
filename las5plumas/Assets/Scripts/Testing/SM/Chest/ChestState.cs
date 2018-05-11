using System;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Testing.ChestSM
{
    [Serializable]
    public class ChestState
    {

        //att
        /*[SerializeField]
        protected UnityEvent OnEnter;
        [SerializeField]
        protected UnityEvent OnUse;
        [SerializeField]
        protected UnityEvent OnExit;*/

        protected ChestState macroState_;
        protected bool active_;
        protected bool current_;

        //properties
        public bool Active { get { return active_; } set { active_ = value; } }

        //contructor
        protected ChestState(ChestState macroState = null, bool active = true) //itself is macroState
        {
            macroState_ = null;

            active_ = true;
            current_ = false;
        }
        protected ChestState(bool active)
        {
            macroState_ = null;

            active_ = true;
            current_ = false;
        }

        //abstract methods
        public virtual void Enter(Chest chest) { current_ = true; /*Invoke(OnEnter);*/ }
        public virtual ChestState Use(Chest chest, Item item) { return null; }
        public virtual void Exit(Chest chest) { current_ = false; /*Invoke(OnExit);*/ }

        protected bool CanUse()
        {
            if (macroState_ != null)
            {
                return active_ && macroState_.current_;
            }

            return active_;
        }

        /*protected void Invoke(UnityEvent e)
        {
            if (e != null)
            {
                e.Invoke();
            }
        }*/
    }
}
