using System;

namespace Project.Testing
{
    //[Serializable]
    public class OpenState : GateState 
    {
        public OpenState(GateState macroState = null, bool active = true, bool current = false) : base(macroState, active, current)
        {
        }

        public override void Enter(Gate gate)
        {
            base.Enter(gate);

            gate.Invoke(gate.OnOpen);
        }

        public override GateState Use(Gate gate, Item item)
        {
            gate.Open();

            return !CanUse() ? null : gate.close_;
        }

        public override void Exit(Gate gate)
        {
            base.Exit(gate);
        }
    }
}
