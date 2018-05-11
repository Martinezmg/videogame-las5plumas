using System;
using UnityEngine;

namespace Project.Testing.ChestSM
{
    [Serializable]
    public class OpenState : ChestState
    {
        public OpenState(bool active) : base(active)
        {
        }

        public OpenState(ChestState macroState = null, bool active = true) : base(macroState, active)
        {
        }

        public override void Enter(Chest chest)
        {
            base.Enter(chest);
            chest.Invoke(chest.OnOpen);
            active_ = false;
        }

        public override void Exit(Chest chest)
        {
            base.Exit(chest);
        }

        public override ChestState Use(Chest chest, Item item)
        {
            //Invoke(OnUse);
            chest.Open();

            return !CanUse() ? null : chest.close_;
        }
    }
}
