using System;

namespace Project.Testing
{
    //[Serializable]
    public class CloseState : GateState 
    {
        public CloseState(GateState macroState = null, bool active = true, bool current = false) : base(macroState, active, current)
        {
        }

        public override void Enter(Gate gate)
        {
            base.Enter(gate);

            //gate.Invoke(gate.OnClose);
        }

        public override GateState Use(Gate gate, Item item)
        {
            gate.Close();

            return !CanUse() ? null : gate.open_;
        }

        public override void Exit(Gate gate)
        {
            base.Exit(gate);
        }
    }
}
