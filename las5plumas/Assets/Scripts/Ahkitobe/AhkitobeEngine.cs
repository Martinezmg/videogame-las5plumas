using UnityEngine;
using UnityEngine.AI;

namespace Project.Game
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AhkitobeEngine : MonoBehaviour
    {
        public NavMeshAgent agent;
        public Transform player;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.stoppingDistance = 2f;
        }

        private void Update()
        {
            agent.SetDestination(player.position);
        }
    }
}
