using UnityEngine;

namespace Project.Game
{
    public class MovementControls : BaseControls
    {
        protected override void TouchUpdate(Touch touch, ref Ray touchRay)
        {
            base.TouchUpdate(touch, ref touchRay);

            if (GameState == GameState.running)
            {

            }
        }
    }
}
