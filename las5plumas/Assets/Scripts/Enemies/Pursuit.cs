using UnityEngine;
using UnityEngine.AI;

public class Pursuit : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private float pursuitSpeed = 1;
    private bool enemyOnSight = false;

    public bool EnemyOnSight
    {
        get
        {
            return enemyOnSight;
        }

        set
        {
            enemyOnSight = value;
        }
    }

    private void Start()
    {
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (enemyOnSight)
            PursuitTarget();
    }

    public void PursuitTarget()
    {
        agent.speed = pursuitSpeed;
        agent.destination = target.position;
    }
}
