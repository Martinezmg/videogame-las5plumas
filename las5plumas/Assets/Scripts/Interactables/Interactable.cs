using UnityEngine;

namespace Project.Interactables
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField]
        protected bool debug = false;

        [SerializeField]
        private float rangedRadius = 5f;    //radius of interactable zone
        [SerializeField]
        private float meleeRadius = 1f;     //radius of interactable zone
        [SerializeField]
        private float specialRadius = 1f;     //radius of interactable zone

        public Transform interactTransform; //if the zone of interact ain't in parent object    
        public bool interactActive = true;

        public Actioner actioner;
        public GameObject particles;

        private void Awake()
        {
            actioner.action -= Interact;
            actioner.action += Interact;
            actioner.specialAction -= SpecialInteract;
            actioner.specialAction += SpecialInteract;
        }

        public virtual void Interact(Transform playerTransform)
        {
            if (!interactActive)
                return;

            float distance = Vector3.Distance(playerTransform.position, interactTransform.position);

            if (distance <= meleeRadius)
            {
                MeleeAction();
            }
            else if (distance > meleeRadius && distance <= rangedRadius)
            {
                RangedAction();
            }
            else
            {
                if (debug)
                    Debug.Log("out of ranged with " + interactTransform.name);
            }
        }

        public virtual void SpecialInteract(Transform playerTransform)
        {
            if (!interactActive)
                return;

            float distance = Vector3.Distance(playerTransform.position, interactTransform.position);

            if (distance <= specialRadius)
                SpecialAction();

        }

        public virtual void RangedAction()
        {
            if (debug)
                Debug.Log("Ranged action with " + interactTransform.name);
        }

        public virtual void MeleeAction()
        {
            if (debug)
                Debug.Log("Melee action with " + interactTransform.name);
        }

        public virtual void SpecialAction()
        {
            if (debug)
                Debug.Log("Special action with " + interactTransform.name);
        }

        private void OnDrawGizmos()
        {
            if (interactTransform == null)
                interactTransform = transform;

            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(interactTransform.position, meleeRadius);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(interactTransform.position, rangedRadius);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(interactTransform.position, specialRadius);
        }

        protected void PlayParticles()
        {
            var go = GameObject.Instantiate(particles, transform.position, transform.rotation).GetComponent<ParticleSystem>();

            go.Play();

            GameObject.Destroy(go.gameObject, go.main.duration);

        }
    }
}