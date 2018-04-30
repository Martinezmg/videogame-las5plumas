using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Game {

    public class NextScene : MonoBehaviour {

        public int sceneNumber;

        public void NextLevel()
        {
            Debug.Log("The scene " + sceneNumber.ToString() + " is about to be loaded.");

            //SceneManager.LoadScene(sceneNumber);
            StartCoroutine(ChangeLvl());
        }

        private IEnumerator ChangeLvl()
        {
            yield return null;

            float fadeTime = MainManager.Instance.GetComponent<Fading>().BeginFade(1);
            yield return new WaitForSeconds(fadeTime);

            SceneManager.LoadScene(sceneNumber);
        }
    } }
