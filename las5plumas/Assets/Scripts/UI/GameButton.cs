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

        public UnityEvent OnTap;

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
            if (OnTap != null)
            {
                OnTap.Invoke();
            }
        }
    }
}
