using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Attack : MonoBehaviour
{
    public UnityEvent OnAttack;

    [SerializeField]
    private bool attackOnce = false;

    [SerializeField]
    private float targetDistance = 0f;

    [SerializeField]
    protected Transform target;

    [SerializeField]
    protected float rangeAttack = 1f;
    [SerializeField]
    protected float attackDelay = 1f;
    [SerializeField]
    private bool isAttacking = false;

    public Color gizmosColor = Color.red;

    public bool IsAttacking
    {
        get
        {
            return isAttacking;
        }

        set
        {
            isAttacking = value;
        }
    }
    

    private void Update()
    {
        if (isAttacking)
            targetDistance = Vector3.Distance(target.position, transform.position);

        /*if (IsAttacking)
            TryToAttackTarget();*/

    }

    private void TryToAttackTarget()
    {
        targetDistance = Vector3.Distance(target.position, transform.position);

        if (targetDistance < rangeAttack * transform.localScale.x)
        {
            AttackTarget();
        }        
    }

    public virtual void AttackTarget()
    {
        Debug.Log("Attacking to " + target.name);
        if (OnAttack != null)
            OnAttack.Invoke();

        if (attackOnce)
            isAttacking = false;
    }

    private IEnumerator AttackTarget_()
    {      
        do
        {
            if (targetDistance < rangeAttack * transform.localScale.x)
            {
                AttackTarget();

                yield return new WaitForSeconds(attackDelay);
            }

        } while (isAttacking);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmosColor;

        Gizmos.DrawWireSphere(transform.position, rangeAttack * transform.localScale.x);
    }
}
