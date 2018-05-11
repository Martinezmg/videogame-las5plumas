using System;

namespace Project.Testing
{
    //[Serializable]
    public class LockState : GateState 
    {
        private const ItemAction UNLOCK = ItemAction.UNLOCK;

        public LockState(GateState macroState = null, bool active = true, bool current = false) : base(macroState, active, current)
        {
        }

        public override void Enter(Gate gate)
        {
            base.Enter(gate);
        }

        public override GateState Use(Gate gate, Item item)
        {
            if (item != null && item.action_ == UNLOCK)
            {
                item.Use();
                return !CanUse() ? null : gate.unlock_;
            }

            return null;
        }

        public override void Exit(Gate gate)
        {
            base.Exit(gate);
        }
    }
}
