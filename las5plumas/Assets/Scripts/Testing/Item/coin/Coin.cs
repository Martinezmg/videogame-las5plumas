using UnityEngine;
using UnityEngine.Events;

namespace Project.Testing
{
    public class Coin : MonoBehaviour
    {
        public UnityEvent OnPickedUp;

        public void PickedUp()
        {
            if (OnPickedUp != null)
            {
                OnPickedUp.Invoke();
            }

            Destroy(gameObject);
        }
    }
}
