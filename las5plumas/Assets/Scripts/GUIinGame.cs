using UnityEngine;
using Project.Game;
using TouchScript.Gestures;
using System;

namespace Project.UI
{
    public class GUIinGame : MonoBehaviour
    {
        enum Points
        {
            inventory, progress, store
        }
        
        public FlickGesture swipeGesture;
        public TouchScript.Gestures.Gesture.GestureState state;
        public CameraController cameraController;

        public Transform pInventory;
        public Transform pProgress;
        public Transform pStore;

        public Transform lastPointInGame;

        private Points currentPoint = Points.inventory;

        private void Awake()
        {
            cameraController = Camera.main.GetComponent<CameraController>();
        }

        private void Update()
        {
            state = swipeGesture.State;
        }

        public void EnableGUIinGame() { enabled = true; }

        public void GoTo(int d)
        {
            switch ((Swipe)d)
            {
                case Swipe.left:
                    Left();
                    break;
                case Swipe.rigth:
                    Rigth();
                    break;
                case Swipe.down:
                    //return to game
                    ReturnToGame();
                    break;
                default:
                    break;
            }

        }

        private void Left()
        {
            switch (currentPoint)
            {
                case Points.progress:
                    cameraController.SetNewTarget(pInventory);
                    break;
                case Points.store:
                    cameraController.SetNewTarget(pProgress);
                    currentPoint = Points.progress;
                    break;
                default:
                    break;
            }
        }
        private void Rigth()
        {
            switch (currentPoint)
            {
                case Points.inventory:
                    cameraController.SetNewTarget(pProgress);
                    currentPoint = Points.progress;
                    break;
                case Points.progress:
                    cameraController.SetNewTarget(pStore);
                    currentPoint = Points.store;
                    break;
                default:
                    break;
            }
        }

        public void ReturnToGame()
        {
            enabled = false;
            currentPoint = Points.inventory;
            GUIManager.instance.GoToGame();
        }

        private void OnEnable()
        {
            swipeGesture.Flicked += SwipeHandler;

            MainManager.Instance.StopGesturesFromGame();

            lastPointInGame.position = cameraController.target.position;
            lastPointInGame.rotation = cameraController.target.rotation;

            cameraController.SetNewTarget(pInventory);
        }
        private void OnDisable()
        {
            swipeGesture.Flicked -= SwipeHandler;

            MainManager.Instance.PlayGesturesFromGame();

            cameraController.SetNewTarget(lastPointInGame); 
        }

        private void SwipeHandler(object sender, EventArgs e)
        {
            Vector2 v = swipeGesture.ScreenFlickVector;

            float x = v.x;
            float y = v.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                    GoTo((int)Swipe.rigth);
                else
                    GoTo((int)Swipe.left);
            }
            else
            {
                if (y < 0)
                    GoTo((int)Swipe.down);
                else
                    GoTo((int)Swipe.up);
            }
        }

    }
}
