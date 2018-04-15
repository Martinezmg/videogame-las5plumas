using System;
using UnityEngine;
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

        public TapGesture tapGesture;
        public TapGesture holdtapGesture;

        #region Singleton
        public static MainManager Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                return;
            }

            Instance = this;
        }
        #endregion

        public void StopGesturesFromGame()
        {
            stopGesturesFromGame();
        }

        public void PlayGesturesFromGame()
        {
            playGesturesFromGame();
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
    }

    
}