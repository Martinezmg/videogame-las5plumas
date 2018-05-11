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
        public Image MotionIndicatorBackground;
        public float IndicatorDistance = 100f;

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
            MotionIndicatorBackground.enabled = true;
            //MotionIndicator.enabled = true;

            MotionIndicatorBackground.transform.position = pos;
        }

        public void UpdateIndicator(float angle)
        {
            if (MotionIndicator.enabled)
            {
                MotionIndicator.transform.eulerAngles = new Vector3(0, 0, -(angle - 90f));
                MotionIndicator.transform.localPosition = new Vector3(IndicatorDistance * Mathf.Sin(Mathf.Deg2Rad * angle), IndicatorDistance * Mathf.Cos(Mathf.Deg2Rad * angle), 0);
            }
            else
            {
                MotionIndicator.enabled = true;
            }

            
        }

        public void UnsetIndicator()
        {
            MotionIndicatorBackground.enabled = false;
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
