using System;
using UnityEngine;

namespace Project.Testing.ChestSM
{
    [Serializable]
    public class CloseState : ChestState
    {
        public CloseState(bool active) : base(active)
        {
        }

        public CloseState(ChestState macroState = null, bool active = true) : base(macroState, active)
        {
        }

        public override void Enter(Chest chest)
        {
            base.Enter(chest);
        }

        public override void Exit(Chest chest)
        {
            base.Exit(chest);


        }

        public override ChestState Use(Chest chest, Item item)
        {
            if (!CanUse())
                return null;

            //Invoke(OnUse);
            chest.Close();

            return chest.open_;
        }
    }
}
