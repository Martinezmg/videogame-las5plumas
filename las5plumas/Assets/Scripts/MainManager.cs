using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TouchScript.Gestures;

namespace Project.Game
{
    public enum GameState
    {
        INGAME,
        INVENTORY,
        MENU,
        MAINSCENE
    }

    public class MainManager : MonoBehaviour
    {
        public GameState currentGameState;

        public bool audioActive = true;
        public AudioSource audioSource;

        public event Action stopGesturesFromGame;
        public event Action playGesturesFromGame;

        public event Action<int> NextScene;

        public TapGesture tapGesture;
        public TapGesture holdtapGesture;


        //public Image fadeImg;

        //[SerializeField]
        //private float fadeSmothness = 1f;

        #region Singleton
        private static MainManager instance;

        public static MainManager Instance { get { return instance; } private set { instance = value; } }

        private MainManager() { }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }/*
            else
            {
                Destroy(gameObject);
                return;
            }*/

            //DontDestroyOnLoad(gameObject);

            //SceneManager.sceneLoaded += FadeIn;
            //SceneManager.sceneUnloaded += FadeOut;
        } 
        #endregion

        public void StopGesturesFromGame()
        {
            if (stopGesturesFromGame != null)
            {
                stopGesturesFromGame();
            }
        }

        public void PlayGesturesFromGame()
        {
            if (playGesturesFromGame != null)
            {
                playGesturesFromGame();
            }
        }

        public void StartGame()
        {
            //if current scene aint mainscene (start of the game) then continue the game
            if (SceneManager.GetActiveScene().name != "MainScene")
            {
                ContinueGame();
                return;
            }

            SceneManager.LoadScene("GameScene");
        }

        public void ContinueGame()
        {
            Debug.Log("Continue Game");
        }

        public void PauseGame()
        {
            Debug.Log("Game PAUSED");
        }

        public void Sound()
        {
            audioActive = !audioActive;
            audioSource.mute = audioActive;

            if (!audioActive)
                Debug.Log("Sound MUTED");
            else
                Debug.Log("Sound UNMUTED");
        }

        public void About()
        {
            Debug.Log("About window open");
        }

        public void Exit()
        {
            Application.Quit();
        }

        public void DebugWarning()
        {
            Debug.Log("Boton!!!!!!!!!!!!!!!!!!!!!!!!!");
        }

        public void ResetCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        /*public void FadeIn(Scene scene, LoadSceneMode mode)
        {
            //Debug.Log("OnSceneLoaded: " + scene.name);
            //Debug.Log(mode);
            StartCoroutine(FadeOut___());
        }

        public void FadeOut(Scene scene)
        {
            //Debug.Log("OnSceneUnloaded: " + scene.name);
            StartCoroutine(FadeIn___());
        }

        private IEnumerator FadeIn___()
        {
            //en algun punto se puede hacer un trigger para los diagolos

            yield return null;

            Color iniColor = fadeImg.color;
            Color finColor = new Color(iniColor.r, iniColor.g, iniColor.b, 255f);

            while (fadeImg.color.a <= 255f)
            {
                iniColor += Color.Lerp(iniColor, finColor, fadeSmothness);
                fadeImg.color = iniColor;

                yield return new WaitForSeconds(2f);
            }
        }

        private IEnumerator FadeOut___()
        {
            //en algun punto se puede hacer un trigger para los diagolos

            yield return null;

            Color iniColor = fadeImg.color;
            Color finColor = new Color(iniColor.r, iniColor.g, iniColor.b, 0f);

            while (fadeImg.color.a > 0f)
            {
                iniColor += Color.Lerp(iniColor, finColor, fadeSmothness);
                fadeImg.color = iniColor;

                yield return new WaitForSeconds(2f);
            }
        }*/
    }

    
}