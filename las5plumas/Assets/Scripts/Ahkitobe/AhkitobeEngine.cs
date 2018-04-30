using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace Project.Game
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AhkitobeEngine : MonoBehaviour
    {
        public NavMeshAgent agent;
        public Transform target;

        //esto no deberia estar en esta clase
        public GameObject dialogPop;

        private void OnEnable()
        {
            StartCoroutine(SlowUpdate());
        }

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            //agent.stoppingDistance = 2f;
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        public void GoTo()
        {
            agent.SetDestination(target.position);
        }

        private IEnumerator SlowUpdate()
        {
            while (true)
            {
                if (agent.velocity.magnitude == 0)
                {
                    transform.rotation = target.rotation;
                }

                yield return new WaitForSeconds(5f);
            }
        }
    }
}
