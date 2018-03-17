using UnityEngine;

namespace Project.Game
{
    public class BaseControls : MonoBehaviour
    {
        internal protected struct TouchV2
        {
            public Touch touch;
            public bool availability;

            public Vector2 position { get { return touch.position; } }
            public int tapCount { get { return touch.tapCount; } }
            public int fingerId { get { return touch.fingerId; } }
            public TouchPhase phase { get { return touch.phase; } }
        }

        private bool isEnable = true;

        protected Ray touchRay0;
        protected Ray touchRay1;

        protected TouchV2 touch0;
        protected TouchV2 touch1;

        public bool IsEnable
        {
            get
            {
                return isEnable;
            }

            set
            {
                isEnable = value;
            }
        }

        private void Start()
        {
            touch0.availability = true;
            touch1.availability = true;
        }

        void Update()
        {
            if (!isEnable) return;

            switch (Input.touchCount)
            {
                case 0:
                    break;
                case 1:
                    touch0.touch = Input.GetTouch(0);

                    TouchUpdate(ref touch0, ref touchRay0);
                    TouchUpdate(ref touch0);
                    break;
                case 2:
                    touch0.touch = Input.GetTouch(0);
                    touch1.touch = Input.GetTouch(1);

                    TouchUpdate(ref touch0, ref touchRay0);
                    TouchUpdate(ref touch1, ref touchRay1);
                    TouchUpdate(ref touch0);
                    TouchUpdate(ref touch1);
                    break;
                default:
                    touch0.touch = Input.GetTouch(0);
                    touch1.touch = Input.GetTouch(1);

                    TouchUpdate(ref touch0, ref touchRay0);
                    TouchUpdate(ref touch1, ref touchRay1);
                    TouchUpdate(ref touch0);
                    TouchUpdate(ref touch1);
                    break;
            }
        }

        protected virtual void TouchUpdate(ref TouchV2 touch) { }

        protected virtual void TouchUpdate(ref TouchV2 touch, ref Ray touchRay)
        {
            Vector3 v1 = new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane);
            Vector3 v2 = new Vector3(touch.position.x, touch.position.y, Camera.main.farClipPlane);

            Vector3 p1 = Camera.main.ScreenToWorldPoint(v1);
            Vector3 p2 = Camera.main.ScreenToWorldPoint(v2);

            touchRay = new Ray(p1, p2 - p1);
        }
    }
}
