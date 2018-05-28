using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public Transform[] points;
    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private float patrolSpeed = 1;

    private int destPoint = 0;
    private bool isNotPatroling = false;

    public bool IsNotPatroling
    {
        get
        {
            return isNotPatroling;
        }

        set
        {
            isNotPatroling = value;
        }
    }

    void Start()
    {
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.speed = patrolSpeed;
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }

    public void GotoNextPoint(float s)
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.speed = s;
        agent.isStopped = false;
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }

    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f && !isNotPatroling)
            GotoNextPoint();
    }
}
