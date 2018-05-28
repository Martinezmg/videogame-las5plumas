using UnityEngine;

public class Barrier : MonoBehaviour
{
    private Animator anim;

    private int upHASH = Animator.StringToHash("upTrigger");
    private int downHASH = Animator.StringToHash("downTrigger");

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PushBarrierUp()
    {
        anim.SetTrigger(upHASH);
    }

    public void PushBarrierDown()
    {
        anim.SetTrigger(downHASH);
    }
}
