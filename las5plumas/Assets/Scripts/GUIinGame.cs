using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Game;

namespace Project.GUI
{
    public class GUIinGame : MonoBehaviour
    {
        enum Points
        {
            inventory, progress, store
        }

        public SwipeControls controls;
        public CameraController cameraController;

        public Transform pInventory;
        public Transform pProgress;
        public Transform pStore;

        public Transform lastPointInGame;

        private Points currentPoint = Points.inventory;

        private void Start()
        {
            cameraController = Camera.main.GetComponent<CameraController>();
            controls.E_swipe += GoTo;
        }

        public void EnableGUIinGame() { enabled = true; }

        public void GoTo(int d)
        {
            if (!enabled)
                return;

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
            if (!enabled)
            {

            }

            Debug.Log("ACTIVATED");

            lastPointInGame.position = cameraController.target.position;
            lastPointInGame.rotation = cameraController.target.rotation;

            cameraController.SetNewTarget(pInventory);
        }

        private void OnDisable()
        {
            Debug.Log("DEACTIVATED");
            cameraController.SetNewTarget(lastPointInGame); 
        }
    }
}
