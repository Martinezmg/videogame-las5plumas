using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class FadingComponent : MonoBehaviour
{
    private int fadeInOutHash = Animator.StringToHash("fadeInOut");
    private int startFadingHash = Animator.StringToHash("startFading");
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private bool isFadeOut = true;
    [SerializeField]
    private bool playInStart = true;

    public UnityEvent OnfadeIn;
    public UnityEvent OnfadeOut;

    public bool FadeInOut
    {
        get
        {
            return isFadeOut;
        }
        set
        {
            isFadeOut = value;

            //llamar a evento
            //anim.SetBool(fadeInOutHash, isFadeOut);
            StartCoroutine(OnFade());
        }
    }

    private void Awake()
    {
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
    }

    private void Start()
    {
        if (playInStart)
            StartCoroutine(OnFade());
    }

    IEnumerator OnFade()
    {
        anim.SetBool(fadeInOutHash, isFadeOut);
        anim.SetTrigger(startFadingHash);
        float speed = anim.GetCurrentAnimatorStateInfo(0).speed;
        speed = Mathf.Abs(speed);

        yield return new WaitForSeconds(2.5f/speed); //tiempo de la animacion actual

        if (isFadeOut)
            Invoke(OnfadeIn);
        else
            Invoke(OnfadeOut);
    }

    private void Invoke(UnityEvent e)
    {
        if (e != null)
            e.Invoke();
    }

}
