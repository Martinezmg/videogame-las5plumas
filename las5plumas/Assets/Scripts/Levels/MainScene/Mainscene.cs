using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Project.GameState;

namespace Project.Levels
{

    public class Mainscene : MonoBehaviour, ISceneCommand
    {
        public GameFile gameDB;

        public UnityEvent OnSceneLoaded;

        public void SceneFinished()
        {
            throw new System.NotImplementedException();
        }

        public void SceneLoaded()
        {
            //chequear si el prologo ya esta completado, de no estarlo ir directamente a el;
            GameState.Level prolog = Array.Find(gameDB.levels, x => x.name == "Prolog");

            if (!prolog.completed)
            {
                //llamar a evento

                Debug.Log("Tengo que entrar al prolog");
                OnSceneLoaded.Invoke();
            }
        }
    }
}
