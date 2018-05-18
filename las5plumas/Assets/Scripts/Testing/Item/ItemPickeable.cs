using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Testing
{
    public class ItemPickeable : Interactable
    {
        public Item item_;

        public float delay = 0f;
        public UnityEvent OnTouch;
        public UnityEvent OnDestroy;

        public override void Touch()
        {

            StartCoroutine(onTouch());    
        }

        private IEnumerator onTouch()
        {
            OnTouch.Invoke();

            yield return new WaitForSeconds(delay);

            AfterTouch();
        }

        public void AfterTouch()
        {
            item_.Take();

            OnDestroy.Invoke();
            Destroy(gameObject);
        }
    }
}
