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

        //public FlickGesture swipeGesture;
        public SwipeGesture swipeGesture;
        public CameraController cameraController;

        public Transform pInventory;
        public Transform pProgress;
        public Transform pStore;

        public Transform lastPointInGame;
        public float lastZoomInGame;

        private Points currentPoint = Points.inventory;

        private void Awake()
        {
            cameraController = Camera.main.GetComponent<CameraController>();
        }


        private void OnEnable()
        {
            swipeGesture.SwipeLeft += Left;
            swipeGesture.SwipeRigth += Rigth;

            MainManager.Instance.StopGesturesFromGame();

            lastPointInGame.position = cameraController.target.position;
            lastPointInGame.rotation = cameraController.target.rotation;
            lastZoomInGame = cameraController.zoomSize;

            cameraController.SetNewTarget(pInventory);
            cameraController.SetNewZoom(3f);
        }
        private void OnDisable()
        {
            swipeGesture.SwipeLeft -= Left;
            swipeGesture.SwipeRigth -= Rigth;

            MainManager.Instance.PlayGesturesFromGame();

            cameraController.SetNewTarget(lastPointInGame);
            cameraController.SetNewZoom(lastZoomInGame);
        }

        public void EnableGUIinGame() { enabled = true; }
                

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
    }
}
