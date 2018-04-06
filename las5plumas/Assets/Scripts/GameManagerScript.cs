using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Game
{
    public enum GameState
    {
        INGAME,
        INVENTORY,
        MENU,
        MAINSCENE
    }

    public class GameManagerScript : MonoBehaviour
    {
        public GameState currentGameState;

        public bool audioActive = true;

        #region Singleton
        public static GameManagerScript instance;

        private void Awake()
        {
            if (instance != null)
            {
                return;
            }

            instance = this;
        }
        #endregion

        

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