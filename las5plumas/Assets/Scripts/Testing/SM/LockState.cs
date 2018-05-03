using System;

namespace Project.Testing
{
    [Serializable]
    public class LockState : GateState
    {
        private const ItemAction UNLOCK = ItemAction.UNLOCK;

        #region Constructor
        public LockState(GateState macroState = null, bool active = true) : base(macroState, active)
        {
        }

        public LockState(bool active) : base(active)
        {
        } 
        #endregion

        public override void Enter(Gate gate)
        {
            base.Enter(gate);
        }

        public override GateState Use(Gate gate, Item item)
        {
            if (!CanUse())
                return null;

            if (item.action_ == UNLOCK)
            {
                item.Use();
                OnUse.Invoke();
                return gate.unlock_;
            }

            return null;
        }

        public override void Exit(Gate gate)
        {
            base.Exit(gate);
        }
    }
}
