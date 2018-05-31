using UnityEngine;
using UnityEngine.Events;

public class Attack : MonoBehaviour
{
    public UnityEvent OnAttack;

    [SerializeField]
    private float targetDistance = 0f;

    protected Sight sight;

    [SerializeField]
    protected float rangeAttack = 1f;
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

    private void Start()
    {
        sight = GetComponent<Sight>();
    }

    private void Update()
    {
        if (IsAttacking)
            TryToAttackTarget();
    }

    private void TryToAttackTarget()
    {
        targetDistance = Vector3.Distance(sight.target.position, transform.position);

        if (targetDistance < rangeAttack * transform.localScale.x)
        {
            AttackTarget();
        }
    }

    public virtual void AttackTarget()
    {
        Debug.Log("Attacking to " + sight.target.name);
        if (OnAttack != null)
            OnAttack.Invoke();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmosColor;

        Gizmos.DrawWireSphere(transform.position, rangeAttack * transform.localScale.x);
    }
}