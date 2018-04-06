using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.GUI
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

        public GameObject gameButtons;
        public GameObject inventoryButtons;
        public GameObject menuButtons;

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
    }
}
