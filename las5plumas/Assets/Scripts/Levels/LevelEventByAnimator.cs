using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Levels
{
    public class LevelEventByAnimator : MonoBehaviour
    {
        public Animator anim;

        public UnityEvent LevelEvent;

        public void AnimationCompleted()
        {
            LevelEvent.Invoke();
        }
    }
}
