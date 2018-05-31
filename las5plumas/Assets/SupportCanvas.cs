using System.Collections;
using UnityEngine;
using TMPro;

namespace Project.DialogueSystem
{
    public class SupportCanvas : MonoBehaviour
    {
        private int activeHash = Animator.StringToHash("Active");

        public TMP_Text supportText;

        public Animator anim;
        public float delay = 1f;

        public void PopSupport(string text)
        {
            supportText.text = text;

            anim.SetBool(activeHash, true);

            StartCoroutine(TimerSupport());
        }

        private IEnumerator TimerSupport()
        {
            yield return new WaitForSeconds(delay);

            anim.SetBool(activeHash, false);
        } 
    }
}
