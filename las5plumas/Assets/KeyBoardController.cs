using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Game.Player
{

    public class KeyBoardController : MonoBehaviour
    {
        public PlayerEngine engine;
        
        // Update is called once per frame
        void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            if (x != 0f || y != 0f)
            {
                engine.RotatePlane();

                float angle = Vector2.SignedAngle(new Vector2(x, y), Vector2.up);
                engine.RotateAgent(angle);

                engine.speedPercent = 1f;

                engine.MoveAgent();
            }
            else
            {
                if (!engine.canMove)
                {
                    engine.speedPercent = 0f;
                }
            }
        }
    }
}
