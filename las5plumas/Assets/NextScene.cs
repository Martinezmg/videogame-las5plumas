using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {

    public int sceneNumber;

	public void NextLevel()
    {
        Debug.Log("The scene " + sceneNumber.ToString() + " is about to be loaded.");

        SceneManager.LoadScene(sceneNumber);
    }
}
