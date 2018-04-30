using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Project.UI
{
    public class GUIManager : MonoBehaviour, IManager
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

        //public event Action UpdateUI;

        public GameObject gameButtons;
        public GameObject inventoryButtons;
        public GameObject menuButtons;

        public ObjectUI ObjectEquipped;

        public Image MotionIndicator;

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

        public void DisableComponent()
        {
            gameObject.SetActive(false);
        }

        public void EnableComponent()
        {
            gameObject.SetActive(true);
        }
    }
}
