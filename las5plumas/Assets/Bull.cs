using UnityEngine;
using UnityEngine.Events;
using Project.Testing;

public class Bull : Interactable
{
    private int hitTriggerHASH = Animator.StringToHash("hitTrigger");

    private Animator anim;

    public int life = 3;

    public UnityEvent OnDeath;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public override void Use(Item item)
    {
        base.Use(item);

        if (!active || item == null) return;

        if (item.action_ == ItemAction.ATTACK)
        {
            active = false;

            anim.SetTrigger(hitTriggerHASH);
            life--;

            if (life <= 0)
            {
                Death();
            }
        }
    }

    private void Death()
    {
        OnDeath.Invoke();

        Destroy(gameObject);
    }
}
