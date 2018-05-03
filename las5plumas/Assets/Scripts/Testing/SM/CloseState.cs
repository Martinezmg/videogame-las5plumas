using System;

namespace Project.Testing
{
    [Serializable]
    public class CloseState : GateState
    {
        #region Constructor
        public CloseState(GateState macroState = null, bool active = true) : base(macroState, active)
        {
        }

        public CloseState(bool active) : base(active)
        {
        } 
        #endregion

        public override void Enter(Gate gate)
        {
            base.Enter(gate);

            gate.Close();
        }

        public override GateState Use(Gate gate, Item item)
        {
            if (!CanUse())
                return null;

            OnUse.Invoke();
            return gate.open_;
        }

        public override void Exit(Gate gate)
        {
            base.Exit(gate);
        }
    }
}
