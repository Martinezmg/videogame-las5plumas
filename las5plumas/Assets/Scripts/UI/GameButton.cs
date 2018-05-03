using Project.Game;
using UnityEngine;
using UnityEngine.Events;
using TouchScript.Gestures;

namespace Project.UI
{
    [RequireComponent(typeof(TapGesture))]
    public class GameButton : MonoBehaviour
    {
        private TapGesture tapGesture;

        private bool check = false;

        public UnityEvent OnTap;
        public UnityEvent OnCheck;
        public UnityEvent OnUncheck;

        private void Awake()
        {
            tapGesture = GetComponent<TapGesture>();
        }

        private void OnEnable()
        {
            tapGesture.Tapped += Tapped;
        }

        private void OnDisable()
        {
            tapGesture.Tapped -= Tapped;
        }

        private void Tapped(object sender, System.EventArgs e)
        {
            check = !check;

            if (OnTap != null)
            {
                OnTap.Invoke();                
            }

            if (OnCheck != null && check)
            {
                OnCheck.Invoke();
            }

            if (OnUncheck != null && !check)
            {
                OnUncheck.Invoke();
            }
        }
    }
}
