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
    private bool isFadeIn = true;
    [SerializeField]
    private bool playInStart = true;

    public UnityEvent OnfadeIn;
    public UnityEvent OnfadeOut;

    public bool FadeInIn
    {
        get
        {
            return isFadeIn;
        }
        set
        {
            isFadeIn = value;

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

    public void FadeInAndOut()
    {

    }
    public void FadeOutAndIn()
    {

    }

    IEnumerator OnFade()
    {
        anim.SetBool(fadeInOutHash, isFadeIn);
        anim.SetTrigger(startFadingHash);
        float speed = anim.GetCurrentAnimatorStateInfo(0).speed;
        speed = Mathf.Abs(speed);

        yield return new WaitForSeconds(2.5f/speed); //tiempo de la animacion actual

        if (isFadeIn)
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
