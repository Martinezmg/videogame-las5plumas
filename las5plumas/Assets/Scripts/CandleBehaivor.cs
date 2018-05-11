using UnityEngine;

[RequireComponent(typeof(Light)), RequireComponent(typeof(Animator))]
public class CandleBehaivor : MonoBehaviour
{
    public float range;

    [SerializeField, Range(0,10)]
    private float escalar = 1;
    [SerializeField, Range(0, 1)]
    private float speed = 1;

    private Light candle;
    private Animator anim;

    private void Start()
    {
        candle = GetComponent<Light>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        candle.range = range * escalar;
        anim.speed = speed;
    }
}
