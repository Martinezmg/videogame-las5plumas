using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class BullAniController : MonoBehaviour
{

    private int enemyInSightHASH  = Animator.StringToHash("enemyInSight");
    private int attackTriggerHASH = Animator.StringToHash("attackTrigger");
    private int jumpTriggerHASH   = Animator.StringToHash("jumpTrigger");
    private int hittedTriggerHASH = Animator.StringToHash("hittedTrigger");
    private int walkTriggerHASH   = Animator.StringToHash("walkTrigger");
    private int crashTriggerHASH  = Animator.StringToHash("crashTrigger");
    private int hitTriggerHASH    = Animator.StringToHash("hitTrigger");

    private Animator anim;
    private NavMeshAgent agent;
    public Transform target;
    public IntVariable targetLife;

    private bool isAttacking = false;

    [Header("Walk State")]
    [SerializeField]
    private float walkSpeed = 1f;
    public Transform[] patrolPoints;

    private bool isPatroling;
    private int destPoint = 0;

    [Header("Alert State")]
    [SerializeField]
    private float timerDelay = 0f;

    private Coroutine timerAlert;

    [Header("Charge State")]
    [SerializeField]
    private float chargeSpeed = 1f;

    [Header("Run State")]
    [SerializeField]
    private float runSpeed = 1f;
    [SerializeField]
    private float attackDistance = 1f;

    [Header("Events")]
    public UnityEvent OnHit;
    public UnityEvent OnHitted;
    public UnityEvent OnCrash;

    private void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (isPatroling)
            Patrol();

        if (isAttacking)
            Attack();
    }

    #region States
    private void Walk()
    {
        if (timerAlert != null)
            StopCoroutine(timerAlert);

        agent.speed = walkSpeed;
        agent.isStopped = false;

        isPatroling = true;
    }
    private void Alert()
    {
        agent.isStopped = true;

        isPatroling = false;
        
        timerAlert = StartCoroutine(TimerAlert(timerDelay));
    }
    private void Prepare()
    {
        Precharge(target);

        isAttacking = true;
    }
    private void Precharge(Transform t)
    {
        agent.destination = t.position;
    }
    private void Charge()
    {
        agent.speed = chargeSpeed;
        agent.isStopped = false;
    }
    private void Run()
    {
        agent.speed = runSpeed;
    }
    private void Jump()
    {

    }
    private void Crash()
    {
        isAttacking = false;
        isPatroling = true;

        agent.isStopped = true;

        OnCrash.Invoke();

        Precharge(patrolPoints[0]);
    }
    private void Hitted()
    {
        Debug.Log("Reduce BULL Life");
        OnHitted.Invoke();
    }
    private void Hit()
    {
        Debug.Log("Reduce Target Life");
        targetLife.Value--;
        
        isAttacking = false;
        isPatroling = true;

        OnHit.Invoke();

        agent.isStopped = true;

        Precharge(patrolPoints[0]);
    }
    #endregion

    private IEnumerator TimerAlert(float delay)
    {
        yield return new WaitForSeconds(delay);

        anim.SetTrigger(attackTriggerHASH); // Go to PrepareState
    }

    private void Patrol()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (patrolPoints.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = patrolPoints[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % patrolPoints.Length;
    }

    private void Attack()
    {
        agent.destination = target.position;

        if (!agent.pathPending && agent.remainingDistance < attackDistance)
            anim.SetTrigger(hitTriggerHASH);
    }
    
    public void EnemyInSight(bool isInSight)
    {
        anim.SetBool(enemyInSightHASH, isInSight);
    }
}
