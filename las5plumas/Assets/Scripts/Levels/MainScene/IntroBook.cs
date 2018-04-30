using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Levels.MainScene
{
    public class IntroBook : MonoBehaviour
    {
        public void AnimationCompleted()
        {
            FindObjectOfType<Mainscene>().SceneLoaded();
        }
    }
}
