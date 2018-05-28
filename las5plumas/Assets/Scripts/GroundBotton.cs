using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GroundBotton : MonoBehaviour
{
    public float yaxis;

    public Transform surface;
    [Range(0f,0.5f)]
    public float offSet = 0f;

    private Vector3 iniSurfacePos;
    private Vector3 iniButtonPos;
    private Vector3 topButtonPos;

    [SerializeField, Range(0f, 1f)]
    private float speed = 1;

    public UnityEvent OnPushDown;
    public UnityEvent OnReset;
    private bool topRuning = false;
    private bool isPushedDown = false;
    public bool buttonActive = true;

    [SerializeField]
    private bool autoReset = false;

    private void Start()
    {
        iniSurfacePos = surface.localPosition;
        iniButtonPos = transform.localPosition;
        topButtonPos = iniSurfacePos + new Vector3(0, transform.localPosition.y - offSet, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!buttonActive)
            return;

        if (other.name == "Player")
        {
            topRuning = true;
            StopAllCoroutines();
            StartCoroutine(Top());             
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!buttonActive)
            return;

        if (other.name == "Player")
        {
            if (!topRuning)
            {
                topButtonPos = iniSurfacePos + new Vector3(0, transform.localPosition.y - offSet, 0);
                surface.position = topButtonPos;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!buttonActive)
            return;

        if (other.name == "Player")
        {
            StopAllCoroutines();
            StartCoroutine(Down());

            if (!isPushedDown || autoReset)
            {
                ResetButton();
            }
        }
    }

    public void ResetButton()
    {
        StopAllCoroutines();

        isPushedDown = false;
        transform.localPosition = iniButtonPos;

        OnReset.Invoke();
    }

    private IEnumerator Top()
    {    
        while (surface.localPosition.y < topButtonPos.y)
        {
            surface.localPosition += Vector3.up *Time.deltaTime* speed;

            yield return null;
        }

        surface.localPosition = topButtonPos;
        topRuning = false;

        if (!isPushedDown)
        {
            isPushedDown = true;
            StartCoroutine(pushButtonDown());            
            if (OnPushDown != null)
            {
                OnPushDown.Invoke();
            }
        }
        
    }

    private IEnumerator Down()
    {
        while (surface.localPosition.y > iniSurfacePos.y)
        {
            surface.localPosition -= Vector3.up *Time.deltaTime* speed;

            yield return null;
        }

        surface.localPosition = iniSurfacePos;
    }

    private IEnumerator pushButtonDown()
    {
        while (transform.localPosition.y > yaxis)
        {
            transform.localPosition -= Vector3.up * Time.deltaTime * speed;

            yield return null;
        }
    }
}
