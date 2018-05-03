﻿using System;

namespace Project.Testing
{
    [Serializable]
    public class UnlockState : GateState
    {
        #region Constructor
        public UnlockState(GateState macroState = null, bool active = true) : base(macroState, active)
        {
        }

        public UnlockState(bool active) : base(active)
        {
        } 
        #endregion

        public override void Enter(Gate gate)
        {
            base.Enter(gate);

            macroState_.Active = true;
        }

        public override GateState Use(Gate gate, Item item)
        {
            if (!CanUse())
                return null;

            OnUse.Invoke();
            return null;
        }

        public override void Exit(Gate gate)
        {
            base.Exit(gate);
        }
    }
}
