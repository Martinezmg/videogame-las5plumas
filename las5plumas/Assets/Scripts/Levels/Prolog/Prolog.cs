using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Project.GameState;

namespace Project.Levels
{
    public class Prolog : MonoBehaviour
    {
        public GameFile gameFile;

        private void OnDisable()
        {
            /*GameState.Level prolog = Array.Find(gameFile.levels, x => x.name == "Prolog");

            prolog.completed = true;*/
        }

        public void Completed()
        {
            GameState.Level prolog = Array.Find(gameFile.levels, x => x.name == "Prolog");

            prolog.completed = true;
        }
    }
}
