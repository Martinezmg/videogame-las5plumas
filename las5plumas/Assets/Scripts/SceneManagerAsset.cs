using UnityEngine;
using UnityEngine.SceneManagement;


[CreateAssetMenu(fileName = "Scene Manager Asset", menuName = "Managers/Scene")]
public class SceneManagerAsset : ScriptableObject
{
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
