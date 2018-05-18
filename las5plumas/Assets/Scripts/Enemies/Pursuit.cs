using UnityEngine;
using UnityEngine.AI;

public class Pursuit : MonoBehaviour
{
    private Sight sight;
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
        sight = GetComponent<Sight>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        PursuitTarget();
    }

    public void PursuitTarget()
    {
        if (enemyOnSight)
        {
            agent.speed = pursuitSpeed;
            agent.destination = sight.target.position;
        }
    }
}
