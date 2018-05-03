using System;

namespace Project.Testing
{
    [Serializable]
    public class OpenState : GateState
    {
        #region Contructor
        public OpenState(GateState macroState = null, bool active = true) : base(macroState, active)
        {
        }

        public OpenState(bool active) : base(active)
        {
        } 
        #endregion

        public override void Enter(Gate gate)
        {
            base.Enter(gate);

            gate.Open();
        }

        public override GateState Use(Gate gate, Item item)
        {
            if (!CanUse())
                return null;

            OnUse.Invoke();
            return gate.close_;
        }

        public override void Exit(Gate gate)
        {
            base.Exit(gate);
        }
    }
}
