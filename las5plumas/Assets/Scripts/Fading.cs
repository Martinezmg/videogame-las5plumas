using System.Collections;
using System;
using UnityEngine;

namespace Project.Game
{

    public class Fading : MonoBehaviour
    {
        public Texture texture;
        public float fadeSpeed;

        private int drawDepth = -1000;
        private float alpha = 1f;
        private int fadeDir = -1;

        public event Action FadeFinished;

        private void OnGUI()
        {
            alpha += fadeDir * fadeSpeed * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);

            GUI.color = new Color(GUI.color.r, GUI.color.b, GUI.color.g, alpha);
            GUI.depth = drawDepth;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
        }

        public float BeginFade(int direction)
        {
            fadeDir = direction;

            return 1f / fadeSpeed;
        }

        private void OnLevelWasLoaded(int level)
        {
            StartCoroutine(FadingTimer(BeginFade(-1)));
        }

        IEnumerator FadingTimer(float t)
        {
            yield return new WaitForSeconds(t);

            if (FadeFinished != null)
            {
                FadeFinished();
            }
        }

    }
}