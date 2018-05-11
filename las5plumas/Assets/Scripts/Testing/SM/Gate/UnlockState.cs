using System;

namespace Project.Testing
{
    //[Serializable]
    public class UnlockState : GateState 
    {
        public UnlockState(GateState macroState = null, bool active = true, bool current = false) : base(macroState, active, current)
        {
        }

        public override void Enter(Gate gate)
        {
            base.Enter(gate);

            macroState_.Active = true;
        }

        public override GateState Use(Gate gate, Item item)
        {


            return  null; //Como siempre retorna null entonces este es el estado final, no puuede pasar de unlock a lock
        }

        public override void Exit(Gate gate)
        {
            base.Exit(gate);
        }
    }
}
