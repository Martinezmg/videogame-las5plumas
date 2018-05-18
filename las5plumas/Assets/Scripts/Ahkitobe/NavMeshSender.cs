using UnityEngine;
using UnityEngine.AI;

public class NavMeshSender : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;

    public void SendAgentTo()
    {
        agent.SetDestination(target.position);
    }
}
