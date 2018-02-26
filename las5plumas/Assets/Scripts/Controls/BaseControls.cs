using UnityEngine;

namespace Project.Game
{
    enum GameState { running, paused};

    public class BaseControls : MonoBehaviour
    {
        GameState gameState = GameState.running;

        protected Ray touchRay0;
        protected Ray touchRay1;

        protected Touch touch0;
        protected Touch touch1;

        internal GameState GameState
        {
            get
            {
                return gameState;
            }

            set
            {
                gameState = value;
            }
        }

        void FixedUpdate()
        {
            switch (Input.touchCount)
            {
                case 0:
                    break;
                case 1:
                    TouchUpdate(Input.GetTouch(0), ref touchRay0);
                    break;
                case 2:
                    TouchUpdate(Input.GetTouch(0), ref touchRay0);
                    TouchUpdate(Input.GetTouch(1), ref touchRay1);
                    break;
                default:
                    TouchUpdate(Input.GetTouch(0), ref touchRay0);
                    TouchUpdate(Input.GetTouch(1), ref touchRay1);
                    break;
            }
        }

        protected virtual void TouchUpdate(Touch touch, ref Ray touchRay)
        {
            if(gameState == GameState.running)
            {
                Vector3 v1 = new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane);
                Vector3 v2 = new Vector3(touch.position.x, touch.position.y, Camera.main.farClipPlane);

                Vector3 p1 = Camera.main.ScreenToWorldPoint(v1);
                Vector3 p2 = Camera.main.ScreenToWorldPoint(v2);

                touchRay = new Ray(p1, p2 - p1);
            }
        }
    }
}
