using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Project.UI
{
    public class GUIManager : MonoBehaviour
    {
        #region Singleton
        public static GUIManager instance;

        private void Awake()
        {
            if (instance != null)
            {
                return;
            }


            instance = this;
        }
        #endregion

        public event Action UpdateUI;

        public GameObject gameButtons;
        public GameObject inventoryButtons;
        public GameObject menuButtons;

        public ObjectUI ObjectEquipped;

        public Image MotionIndicator;
        
        
        private void OnEnable()
        {
            SceneManager.sceneLoaded += FadeIn;
            SceneManager.sceneUnloaded += FadeOut;
        }

        public void GoToGame()
        {
            gameButtons.SetActive(true);

            inventoryButtons.SetActive(false);
            menuButtons.SetActive(false);
        }
        public void GoToInventory()
        {
            inventoryButtons.SetActive(true);

            gameButtons.SetActive(false);
            menuButtons.SetActive(false);
        }
        public void GoToMenu()
        {
            menuButtons.SetActive(true);

            gameButtons.SetActive(false);
            inventoryButtons.SetActive(false);
        }

        

        public void FadeIn(Scene scene, LoadSceneMode mode)
        {
            //Debug.Log("OnSceneLoaded: " + scene.name);
            //Debug.Log(mode);
        }

        public void FadeOut(Scene scene)
        {
            //Debug.Log("OnSceneUnloaded: " + scene.name);
        }

        public void SetIndicator(Vector2 pos)
        {
            MotionIndicator.enabled = true;

            MotionIndicator.transform.position = pos;
        }

        public void UpdateIndicator(float angle)
        {
            MotionIndicator.transform.eulerAngles = new Vector3(0, 0, -(angle - 90f));
        }

        public void UnsetIndicator()
        {
            MotionIndicator.enabled = false;
        }
    }
}
